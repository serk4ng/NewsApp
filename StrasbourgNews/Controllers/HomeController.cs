using PagedList;
using StrasbourgNews.DAL.Models;
using StrasbourgNews.Domain.Enums;
using StrasbourgNews.Domain.ViewModels;
using StrasbourgNews.Services.DBServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StrasbourgNews.Controllers
{
    public class HomeController : BaseController
    {
        private readonly NewsServices _NewsServices;
        public IPagedList<NewsViewModel> serviceResultNews;

        public IQueryable<SermonViewModel> serviceResultSermons;
        BaseViewModel basevm;

        List<NewsViewModel> mainNews;
         public static int catcounter = 0;
 
        List<List<NewsViewModel>> catnewslist = new List<List<NewsViewModel>>();

        NewsViewModel[,] NewsWithCategory = new NewsViewModel[30,10];
 


        private readonly SubscriberServices _SubscriberServices;
        private readonly NewsCategoryServices _NewsCategoryServices;
        private readonly SermonServices _SermonServices;
        public HomeController()
        {
            _NewsServices = new NewsServices(_unitOfWork);
            _SubscriberServices = new SubscriberServices(_unitOfWork);
            _NewsCategoryServices = new NewsCategoryServices(_unitOfWork);
            _SermonServices = new SermonServices(_unitOfWork);
        }
        public ActionResult Index()
        {
            if (Session["selectedlang"].ToString() == "1")
            {
                mainNews = _NewsServices.GetAllTR().OrderByDescending(x => x.CreationDate).Skip(Math.Max(0, _NewsServices.GetAllTR().Count() - 4)).ToList();

                GetCategoryNewsTR();

            }
            else
            {
                mainNews = _NewsServices.GetAllFR().OrderByDescending(x => x.CreationDate).Skip(Math.Max(0, _NewsServices.GetAllFR().Count() - 4)).ToList();

                GetCategoryNewsFR();
            }
            GetSermon();


            return View(new Tuple<List<NewsViewModel>, NewsViewModel[,], IQueryable<SermonViewModel>>(mainNews, NewsWithCategory, serviceResultSermons));
        }

        public void GetCategoryNewsTR()
        {
            List<NewsCategoryViewModel> trcategorylist = _NewsCategoryServices.GetAllTR().ToList();

            catcounter = _NewsServices.GetAllTR().GroupBy(x => x.Category).Where(x => x.Count() >= 5).Count();
    

            for (int i = 0; i < trcategorylist.Count; i++)
            {
                     
                string mycat = trcategorylist[i].Category;
                int trnewscount = _NewsServices.GetAllTR().Where(x => x.Category == mycat).OrderByDescending(x => x.CreationDate).Skip(Math.Max(0, _NewsServices.GetAllTR().Where(x => x.Category == mycat).Count() - 5)).ToArray().Count();
                if (trnewscount >= 5)
                {
                    
                    var trnewslist = _NewsServices.GetAllTR().Where(x => x.Category == mycat).OrderByDescending(x => x.CreationDate).Skip(Math.Max(0, _NewsServices.GetAllTR().Where(x => x.Category == mycat).Count() - 5)).ToArray();
                    ViewData["category" + i] = trcategorylist[i].Category;
                    for (int j = 0; j < 5; j++)
                    {
                        NewsWithCategory[i, j] = trnewslist[j];

                    }
                }


                //_NewsCategoryServices.GetAll().Where(x => x.SiteLanguage == (SiteLanguages)1).Where(x=>x.Category == trcategorylist[i].Category).Skip(Math.Max(0, _NewsServices.GetAllTR().Count() - 4)).ToList();
            }
        }
        public void GetCategoryNewsFR()
        {
            List<NewsCategoryViewModel> frcategorylist = _NewsCategoryServices.GetAllFR().ToList();

            catcounter = _NewsServices.GetAllFR().GroupBy(x => x.Category).Where(x => x.Count() >= 5).Count();
            for (int i = 0; i < frcategorylist.Count; i++)
            {
                string mycat = frcategorylist[i].Category;
                int frnewscount = _NewsServices.GetAllFR().Where(x => x.Category == mycat).OrderByDescending(x => x.CreationDate).Skip(Math.Max(0, _NewsServices.GetAllFR().Where(x => x.Category == mycat).Count() - 5)).ToArray().Count();
                if (frnewscount >= 5)
                {
                     
                    var frnewslist = _NewsServices.GetAllFR().Where(x => x.Category == mycat).OrderByDescending(x => x.CreationDate).Skip(Math.Max(0, _NewsServices.GetAllFR().Where(x => x.Category == mycat).Count() - 5)).ToArray();
                    ViewData["category" + i] = frcategorylist[i].Category;
                    for (int j = 0; j < 5; j++)
                    {
                        NewsWithCategory[i, j] = frnewslist[j];

                    }
                }


                //_NewsCategoryServices.GetAll().Where(x => x.SiteLanguage == (SiteLanguages)1).Where(x=>x.Category == trcategorylist[i].Category).Skip(Math.Max(0, _NewsServices.GetAllTR().Count() - 4)).ToList();
            }
        }

        public void GetSermon()
        {
            if (Session["selectedlang"].ToString() == "1")
            {
                serviceResultSermons = _SermonServices.GetAllTR().OrderByDescending(x => x.CreationDate).Skip(Math.Max(0, _SermonServices.GetAllTR().Count() - 4));
            }
            else
            {
                serviceResultSermons = _SermonServices.GetAllFR().OrderByDescending(x => x.CreationDate).Skip(Math.Max(0, _SermonServices.GetAllFR().Count() - 4));
            }
        }
        public ActionResult CatNext()
        {
            int def_counter = Int32.Parse(Session["cat1"].ToString());

            if (def_counter < catcounter-1 )
            {
                def_counter++;

                Session["cat1"] = def_counter;
            }
        

            return RedirectToAction("Index", "Home");
        }
        public ActionResult CatPrev()
        {
            int def_counter = Int32.Parse(Session["cat1"].ToString());

            if (def_counter > 0)
            {
                def_counter--;

                Session["cat1"] = def_counter;
            }


            return RedirectToAction("Index", "Home");
        }

        public ActionResult DitibNews(int? page)
        {
            if (Session["selectedlang"].ToString() == "1")
            {
                serviceResultNews = _NewsServices.GetAllTR().OrderByDescending(x => x.CreationDate).Where(x => x.NewsType == (NewsType)1).ToPagedList(page ?? 1, 6);
           
            }
            else
            {
                serviceResultNews = _NewsServices.GetAllFR().OrderByDescending(x => x.CreationDate).Where(x => x.NewsType == (NewsType)1).ToPagedList(page ?? 1, 6);

            }

            return View(serviceResultNews);
        }

        public ActionResult AssociationNews(int? page)
        {
            if (Session["selectedlang"].ToString() == "1")
            {
                serviceResultNews = _NewsServices.GetAllTR().OrderByDescending(x => x.CreationDate).Where(x => x.NewsType == (NewsType)2).ToPagedList(page ?? 1, 6);



            }
            else
            {
                serviceResultNews = _NewsServices.GetAllFR().OrderByDescending(x => x.CreationDate).Where(x => x.NewsType == (NewsType)2).ToPagedList(page ?? 1, 6);

            }
            return View(serviceResultNews);
        }

        public ActionResult NewsDetail(int? Id)
        {
            var serviceResult = _NewsServices.Get(Id);
            return View(serviceResult);
        }

        public ActionResult SubscriberSave(SubscriberViewModel viewModel)
        {
            _SubscriberServices.Add(viewModel);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
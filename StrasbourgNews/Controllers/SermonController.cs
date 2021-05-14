using PagedList;
using StrasbourgNews.Domain.ViewModels;
using StrasbourgNews.Services.DBServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StrasbourgNews.Controllers
{
    public class SermonController : BaseController
    {
        private readonly SermonServices _SermonServices;
        public IPagedList<SermonViewModel> serviceResultNews;

        public SermonController()
        {
            _SermonServices = new SermonServices(_unitOfWork);

        }

        public ActionResult Index(int? page)
        {
            if (Session["selectedlang"].ToString() == "1")
            {
                serviceResultNews = _SermonServices.GetAllTR().OrderByDescending(x => x.CreationDate).ToPagedList(page ?? 1, 6);



            }
            else
            {
                serviceResultNews = _SermonServices.GetAllFR().OrderByDescending(x => x.CreationDate).ToPagedList(page ?? 1, 6);
            }

            return View(serviceResultNews);
        }

        public ActionResult SermonDetail(int? Id)
        {
            var serviceResult = _SermonServices.Get(Id);
            return View(serviceResult);
        }
    }
}
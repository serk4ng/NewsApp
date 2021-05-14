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
    public class PublicationController : BaseController
    {
        private readonly PublicationServices _PublicationServices;
        public IPagedList<PublicationViewModel> serviceResultNews;
        public PublicationController()
        {
            _PublicationServices = new PublicationServices(_unitOfWork);
       
        }

        public ActionResult Index(int? page)
        {
            if (Session["selectedlang"].ToString() == "1")
            {
                serviceResultNews = _PublicationServices.GetAllTR().OrderByDescending(x => x.CreationDate).ToPagedList(page ?? 1, 8);



            }
            else
            {
                serviceResultNews = _PublicationServices.GetAllFR().OrderByDescending(x => x.CreationDate).ToPagedList(page ?? 1, 8);

            }

            return View(serviceResultNews);
        }
    }
}
using FluentValidation;
using StrasbourgNews.DAL.UnitOfWork;
using StrasbourgNews.Domain.ViewModels;
using StrasbourgNews.Services.DBServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StrasbourgNews.Controllers
{
    public class BaseController : Controller
    {
        public readonly STNUnitOfWork _unitOfWork;
        public static int counter = 0;

        private readonly SiteSettingsServices _siteSettingsServices;

        private readonly NewsServices _NewsServices;
        public BaseController()
        {
            _unitOfWork = new STNUnitOfWork();
           _siteSettingsServices = new SiteSettingsServices(_unitOfWork);
           _NewsServices = new NewsServices(_unitOfWork);

        }

        protected override void Initialize(RequestContext requestContext)
        {

            base.Initialize(requestContext);
            if (counter == 0)
            {
                Session["selectedlang"] = "1";
                Session["cat1"] = "0";
                counter++;
            }

            if (Session["selectedlang"].ToString() == "1")
            {
                ViewBag.siteSettings = _siteSettingsServices.Get(2);

                var lastNews = _NewsServices.GetAllTR().OrderByDescending(x => x.CreationDate).Skip(Math.Max(0, _NewsServices.GetAllTR().Count() - 5)).ToList();
               
               

                ViewBag.lastNews = lastNews;

  
            }
            else
            {
                ViewBag.siteSettings = _siteSettingsServices.Get(14);
                var lastNews = _NewsServices.GetAllFR().OrderByDescending(x => x.CreationDate).Skip(Math.Max(0, _NewsServices.GetAllFR().Count() - 5)).ToList();
                ViewBag.lastNews = lastNews;
            }

        }

     
        public bool Validate<TModel, TValidator>(TModel model, TValidator validator, ModelStateDictionary modelState)
        where TValidator : AbstractValidator<TModel>
        {
            FluentValidation.Results.ValidationResult result = validator.Validate(model);

            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return result.IsValid;
        }

        public ActionResult Language(int lang)
        {
            Session["selectedlang"] = lang;
            return RedirectToAction("Index", "Home");
        }



    }
}
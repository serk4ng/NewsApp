using StrasbourgNews.DAL.Models;
using StrasbourgNews.DAL.Repository;
using StrasbourgNews.DAL.UnitOfWork;
using StrasbourgNews.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrasbourgNews.Services.DBServices
{
    public class SiteSettingsServices : BaseServices
    {
        private readonly STNRepository<SiteSettings> _repository;

        public SiteSettingsServices(STNUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STNRepository<SiteSettings>(unitOfWork);
        }

        public SiteSettingsViewModel Get(int? Id)
        {
            var settings = _repository.Get(x => x.Id == Id);

            return new SiteSettingsViewModel
            {
                CreationDate = settings.CreationDate,
                Status = settings.Status,
                IsItDeleted = settings.IsItDeleted,
                DateOfUpdate = settings.DateOfUpdate,
                Id = settings.Id,

                SiteLanguage = settings.SiteLanguage,

                AboutUs = settings.AboutUs,
                OurGoals = settings.OurGoals,
                Principle = settings.Principle,
                Logo = settings.Logo,
                Map = settings.Map,
                Phone = settings.Phone,
                Adress = settings.Adress,
                Email = settings.Email,
                Fax = settings.Fax,


                Facebook = settings.Facebook,
                Twitter = settings.Twitter,
                Instagram = settings.Twitter,
                Youtube = settings.Youtube,

                Slider1 = settings.Slider1,
                Slider2 = settings.Slider2,
                Slider3 = settings.Slider3,
                Slider4 = settings.Slider4,

            };
        }

        public IQueryable<SiteSettingsViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new SiteSettingsViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,

                    SiteLanguage = x.SiteLanguage,

                    AboutUs = x.AboutUs,
                    OurGoals = x.OurGoals,
                    Principle = x.Principle,
                    Logo = x.Logo,
                    Map = x.Map,
                    Phone = x.Phone,
                    Adress = x.Adress,
                    Email = x.Email,
                    Fax = x.Fax,


                    Facebook = x.Facebook,
                    Twitter = x.Twitter,
                    Instagram = x.Twitter,
                    Youtube = x.Youtube,

                    Slider1 = x.Slider1,
                    Slider2 = x.Slider2,
                    Slider3 = x.Slider3,
                    Slider4 = x.Slider4,
                });
        }
    }
}

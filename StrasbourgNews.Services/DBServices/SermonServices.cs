using StrasbourgNews.DAL.Models;
using StrasbourgNews.DAL.Repository;
using StrasbourgNews.DAL.UnitOfWork;
using StrasbourgNews.Domain.Enums;
using StrasbourgNews.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrasbourgNews.Services.DBServices
{
    public class SermonServices : BaseServices
    {
        private readonly STNRepository<Sermon> _repository;

        public SermonServices(STNUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STNRepository<Sermon>(unitOfWork);
        }

        public SermonViewModel Get(int? Id)
        {
            var sermons = _repository.Get(x => x.Id == Id);

            return new SermonViewModel
            {
                CreationDate = sermons.CreationDate,
                Status = sermons.Status,
                IsItDeleted = sermons.IsItDeleted,
                DateOfUpdate = sermons.DateOfUpdate,
                Id = sermons.Id,
                SiteLanguage = sermons.SiteLanguage,
                Title = sermons.Title,
                Content = sermons.Content,
                Image = sermons.Image



            };
        }

        public IQueryable<SermonViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new SermonViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,
                    Title = x.Title,
                    Content = x.Content,
                    Image = x.Image,

                });
        }

        public IQueryable<SermonViewModel> GetAllTR()
        {
            return _repository.GetList()
                .Select(x => new SermonViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,
                    Title = x.Title,
                    Content = x.Content,
                    Image = x.Image,

                }).Where(x => x.SiteLanguage == (SiteLanguages)1); ;
        }

        public IQueryable<SermonViewModel> GetAllFR()
        {
            return _repository.GetList()
                .Select(x => new SermonViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,
                    Title = x.Title,
                    Content = x.Content,
                    Image = x.Image,

                }).Where(x => x.SiteLanguage == (SiteLanguages)2); ;
        }


    }
}

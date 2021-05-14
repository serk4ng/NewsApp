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
    public class PublicationServices : BaseServices
    {
        private readonly STNRepository<Publication> _repository;

        public PublicationServices(STNUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STNRepository<Publication>(unitOfWork);
        }

        public PublicationViewModel Get(int? Id)
        {
            var publication = _repository.Get(x => x.Id == Id);

            return new PublicationViewModel
            {
                CreationDate = publication.CreationDate,
                Status = publication.Status,
                IsItDeleted = publication.IsItDeleted,
                DateOfUpdate = publication.DateOfUpdate,
                Id = publication.Id,
                SiteLanguage = publication.SiteLanguage,

                Name = publication.Name,
                Description = publication.Description,
                Image = publication.Image

            };
        }

        public IQueryable<PublicationViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new PublicationViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,
                    Name = x.Name,
                    Description = x.Description,
                    Image = x.Image,

                });
        }

        public IQueryable<PublicationViewModel> GetAllTR()
        {
            return _repository.GetList()
                .Select(x => new PublicationViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,
                    Name = x.Name,
                    Description = x.Description,
                    Image = x.Image,

                }).Where(x => x.SiteLanguage == (SiteLanguages)1);
        }

        public IQueryable<PublicationViewModel> GetAllFR()
        {
            return _repository.GetList()
                .Select(x => new PublicationViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,
                    Name = x.Name,
                    Description = x.Description,
                    Image = x.Image,

                }).Where(x => x.SiteLanguage == (SiteLanguages)2);
        }



    }
}

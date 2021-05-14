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
    public class NewsCategoryServices : BaseServices
    {
        private readonly STNRepository<NewsCategory> _repository;


        public NewsCategoryServices(STNUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STNRepository<NewsCategory>(unitOfWork);
        }


 
 
        public NewsCategoryViewModel Get(int? Id)
        {
            var newscategory = _repository.Get(x => x.Id == Id);

            return new NewsCategoryViewModel
            {
                CreationDate = newscategory.CreationDate,
                Status = newscategory.Status,
                IsItDeleted = newscategory.IsItDeleted,
                DateOfUpdate = newscategory.DateOfUpdate,
                Id = newscategory.Id,
                SiteLanguage = newscategory.SiteLanguage,
                Category = newscategory.CategoryName

            };
        }
 
        public IQueryable<NewsCategoryViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new NewsCategoryViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,
                    Category = x.CategoryName


                });
        }

        public IQueryable<NewsCategoryViewModel> GetAllTR()
        {
            return _repository.GetList()
                .Select(x => new NewsCategoryViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,
                    Category = x.CategoryName


                }).Where(x=>x.SiteLanguage == (SiteLanguages)1);
        }

        public IQueryable<NewsCategoryViewModel> GetAllFR()
        {
            return _repository.GetList()
                .Select(x => new NewsCategoryViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,
                    Category = x.CategoryName


                }).Where(x => x.SiteLanguage == (SiteLanguages)2);
        }



    }
}

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
    public class NewsServices : BaseServices
    {
        private readonly STNRepository<News> _repository;

        public NewsServices(STNUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STNRepository<News>(unitOfWork);
        }


        public NewsViewModel Get(int? Id)
        {
            var news = _repository.Get(x => x.Id == Id);

            return new NewsViewModel
            {
                CreationDate = news.CreationDate,
                Status = news.Status,
                IsItDeleted = news.IsItDeleted,
                DateOfUpdate = news.DateOfUpdate,
                Id = news.Id,
                SiteLanguage = news.SiteLanguage,
                Title = news.Title,
                Content = news.Content,
                Image = news.Image,
                Category = news.Category,
                NewsType = news.NewsType




            };
        }

        public IQueryable<NewsViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new NewsViewModel
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
                    NewsType = x.NewsType,
                    Category = x.Category

                });
        }

        public IQueryable<NewsViewModel> GetAllTR()
        {
            return _repository.GetList()
                .Select(x => new NewsViewModel
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
                    NewsType = x.NewsType,
                    Category = x.Category

                }).Where(x => x.SiteLanguage == (SiteLanguages)1); ;
        }

        public List<NewsViewModel> GetAllTR_List()
        {
            return (List<NewsViewModel>)_repository.GetList()
                .Select(x => new NewsViewModel
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
                    NewsType = x.NewsType,
                    Category = x.Category

                }).Where(x => x.SiteLanguage == (SiteLanguages)1); ;
        }

        public IQueryable<NewsViewModel> GetAllFR()
        {
            return _repository.GetList()
                .Select(x => new NewsViewModel
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
                    NewsType = x.NewsType,
                    Category = x.Category

                }).Where(x => x.SiteLanguage == (SiteLanguages)2); ;
        }

    }
}

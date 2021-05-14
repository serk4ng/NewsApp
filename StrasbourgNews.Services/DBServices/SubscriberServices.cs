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
    public class SubscriberServices : BaseServices
    {
        private readonly STNRepository<Subscriber> _repository;

        public SubscriberServices(STNUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STNRepository<Subscriber>(unitOfWork);
        }

        public void Add(SubscriberViewModel viewModel)
        {
            _repository.Add(new Subscriber
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,

                Email = viewModel.Email

            });
        }
    }
}

using StrasbourgNews.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrasbourgNews.Services.DBServices
{
    public abstract class BaseServices
    {
        public BaseServices(STNUnitOfWork unitOfWork)
        {

        }
    }
}

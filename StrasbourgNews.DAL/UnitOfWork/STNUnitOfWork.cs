using StrasbourgNews.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrasbourgNews.DAL.UnitOfWork
{
    public class STNUnitOfWork : IDisposable
    {
        private readonly ApplicationContext _context;

        public STNUnitOfWork()
        {
            _context = new ApplicationContext();
        }

        public ApplicationContext GetContext()
        {
            return _context;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

using StrasbourgNews.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;
namespace StrasbourgNews.DAL.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        : base("Server=.; Database=Strasbourg; User Id=sa; Pwd=123;")
        {

        }
        public DbSet<News> News { get; set; }
        public DbSet<SiteSettings> SiteSettings { get; set; }
        public DbSet<Sermon> Sermons { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
    }
}

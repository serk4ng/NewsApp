using StrasbourgNews.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrasbourgNews.DAL.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public bool IsItDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DateOfUpdate { get; set; }
        public SiteLanguages SiteLanguage { get; set; }
    }
}

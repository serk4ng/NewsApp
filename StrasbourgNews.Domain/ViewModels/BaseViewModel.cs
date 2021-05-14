using StrasbourgNews.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrasbourgNews.Domain.ViewModels
{
    public abstract class BaseViewModel
    {

        [Display(Name = "Id : ")]
        public int Id { get; set; }

        [Display(Name = "Durum : ")]
        public bool Status { get; set; }

        [Display(Name = "Silindi mi : ")]
        public bool IsItDeleted { get; set; }

        [Display(Name = "Oluşturulma Tarihi : ")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Güncellenme Tarihi : ")]
        public DateTime? DateOfUpdate { get; set; }

        [Display(Name = "Site Dili : ")]
        public SiteLanguages SiteLanguage { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrasbourgNews.Domain.ViewModels
{
    public class SiteSettingsViewModel : BaseViewModel
    {
        [Display(Name = "Logo : ")]
        public string Logo { get; set; }
        [Display(Name = "Adres : ")]
        public string Adress { get; set; }
        [Display(Name = "Email : ")]
        public string Email { get; set; }
        [Display(Name = "Telefon : ")]
        public string Phone { get; set; }
        [Display(Name = "Fax : ")]
        public string Fax { get; set; }
        [Display(Name = "Harita : ")]
        public string Map { get; set; }
        [Display(Name = "Hakkımızda : ")]
        public string AboutUs { get; set; }
        [Display(Name = "Hedeflerimiz : ")]
        public string OurGoals { get; set; }
        [Display(Name = "İlkelerimiz : ")]
        public string Principle { get; set; }
        [Display(Name = "Facebook : ")]
        public string Facebook { get; set; }
        [Display(Name = "Twitter : ")]
        public string Twitter { get; set; }
        [Display(Name = "Instagram : ")]
        public string Instagram { get; set; }
        [Display(Name = "Youtube : ")]
        public string Youtube { get; set; }


        [Display(Name = "Slider 1 : ")]
        public string Slider1 { get; set; }

        [Display(Name = "Slider 2 : ")]
        public string Slider2 { get; set; }

        [Display(Name = "Slider 3 : ")]
        public string Slider3 { get; set; }

        [Display(Name = "Slider 4 : ")]
        public string Slider4 { get; set; }
    }
}

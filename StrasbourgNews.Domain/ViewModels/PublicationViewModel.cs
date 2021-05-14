using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrasbourgNews.Domain.ViewModels
{
    public class PublicationViewModel : BaseViewModel
    {
        [Display(Name = "Ad : ")]
        public string Name { get; set; }
        [Display(Name = "Resim : ")]
        public string Image { get; set; }
        [Display(Name = "Açıklama : ")]
        public string Description { get; set; }
    }
}

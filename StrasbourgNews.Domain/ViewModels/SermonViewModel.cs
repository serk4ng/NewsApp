using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrasbourgNews.Domain.ViewModels
{
    public class SermonViewModel : BaseViewModel
    {
        [Display(Name = "Başlık : ")]
        public string Title { get; set; }
        [Display(Name = "İçerik : ")]
        public string Content { get; set; }
        [Display(Name = "Resim : ")]
        public string Image { get; set; }

    }
}

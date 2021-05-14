using StrasbourgNews.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrasbourgNews.Domain.ViewModels
{
    public class NewsViewModel : BaseViewModel
    {
        [Display(Name = "Başlık : ")]
        public string Title { get; set; }

        [Display(Name = "İçerik : ")]
        public string Content { get; set; }
        [Display(Name = "Kategori : ")]
        public string Category { get; set; }

        [Display(Name = "Haber Tipi : ")]
        public NewsType NewsType { get; set; }

        [Display(Name = "Resim : ")]
        [DataType(DataType.Upload)]
        public string Image { get; set; }



    }
}

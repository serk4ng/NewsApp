using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrasbourgNews.Domain.ViewModels
{
    public class NewsCategoryViewModel : BaseViewModel
    {
        [Display(Name = "Kategori : ")]
        public string Category { get; set; }

    }
}

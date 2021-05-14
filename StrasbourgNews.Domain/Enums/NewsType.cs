using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrasbourgNews.Domain.Enums
{
    public enum NewsType : byte
    {
        [Display(Name = "Ditibden Haberler")]
        Ditibden = 1,
        [Display(Name = "Derneklerden Haberler")]
        Derneklerden = 2



    }
}

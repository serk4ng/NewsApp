using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrasbourgNews.DAL.Models
{
    public class Publication : BaseModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrasbourgNews.DAL.Models
{
    public class Sermon : BaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }

    }
}

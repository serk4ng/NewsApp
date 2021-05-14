using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrasbourgNews.DAL.Models
{
    public class SiteSettings : BaseModel
    {
        public string Logo { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Map { get; set; }
        public string AboutUs { get; set; }
        public string OurGoals { get; set; }
        public string Principle { get; set; }

        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Youtube { get; set; }



        public string Slider1 { get; set; }
        public string Slider2 { get; set; }
        public string Slider3 { get; set; }
        public string Slider4 { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.NET._2.Myalik.SocialNet.Models.Interface;

namespace ASP.NET._2.Myalik.SocialNet.Models
{
    public class CountryViewModel : IViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
}
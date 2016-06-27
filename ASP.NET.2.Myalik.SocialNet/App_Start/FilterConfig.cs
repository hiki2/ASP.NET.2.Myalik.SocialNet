using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET._2.Myalik.SocialNet.Filter.Filters.Filters;

namespace ASP.NET._2.Myalik.SocialNet.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MyExceptionFilter());
        }
    }
}
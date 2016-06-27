using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET._2.Myalik.SocialNet.Filter
{
    namespace Filters.Filters
    {
        public class MyExceptionFilter : FilterAttribute, IExceptionFilter
        {
            public void OnException(ExceptionContext exceptionContext)
            {
                if (exceptionContext.ExceptionHandled || exceptionContext.Exception == null) return;
                exceptionContext.Result = new RedirectResult("../Eror/Index");
                exceptionContext.ExceptionHandled = true;
            }
        }
    }
}
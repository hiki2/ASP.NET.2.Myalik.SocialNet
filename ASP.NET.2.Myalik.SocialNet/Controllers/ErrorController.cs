using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET._2.Myalik.SocialNet.Models;

namespace ASP.NET._2.Myalik.SocialNet.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(string message, int? code)
        {
            if (code == null)
                code = 404;
            if (message == null)
                message = "Not Found";
            return PartialView(new ErrorViewModel
            {
                Code = (int)code,
                Message = message
            });
        }

        public ActionResult BadRequest()
        {
            return Index("Bad Request",400);
        }

        public ActionResult Forbidden()
        {
            return Index("Forbidden",403);
        }

        public ActionResult Internal()
        {
            return Index("Internal Server Error",500);
        }
    }
}
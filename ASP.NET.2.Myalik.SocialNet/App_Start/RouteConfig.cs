﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASP.NET._2.Myalik.SocialNet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Home",
                url : "Home/{profileId}",
                defaults: new { controller= "Home", action = "Index" ,profileId = UrlParameter.Optional}
                );

            routes.MapRoute(
                name: "User",
                url: "Friends/{profileId}",
                defaults: new { controller = "User", action = "FriendsList", profileId = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Error",
                url:"*{url}",
                defaults: new {controller = "Error",action = "Index"}
                );
        }
    }
}

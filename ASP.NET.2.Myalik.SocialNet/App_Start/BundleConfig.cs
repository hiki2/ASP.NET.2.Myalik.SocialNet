using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ASP.NET._2.Myalik.SocialNet.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/metro-ui")
                .Include("~/scripts/jquery-1.10.2.min.js")
                .Include("~/scripts/jquery.unobtrusive-ajax.min.js")
                 //.Include("~/scripts/jquery.validate.unobtrusive.min.js")
                 //.Include("~/scripts/jquery.validate.min.js")
                 //.Include("~/scripts/jquery.validate-vsdoc.js")
                .Include("~/scripts/metro.min.js")
                //.Include("~/scripts/modernizr-2.6.2.js")
                );

            bundles.Add(new StyleBundle("~/Content/mentro-ui")
                .Include("~/Content/metro-icons.min.css")
                .Include("~/Content/metro-responsive.min.css")
                .Include("~/Content/metro-rtl.min.css")
                .Include("~/Content/metro-schemes.min.css")
                .Include("~/Content/metro.min.css")
                //.Include("~/Content/Site.css")
                );
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Optimization;

namespace TallerWeb.App_Start
{
    public class BundleConfig
    {
        //
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css").Include("~/Styles/css/*.css"));
            bundles.Add(new ScriptBundle("~/bundles/librerias").Include("~/LibreriasJS/angular.min.js"
                                                                        , "~/LibreriasJS/angular-ui-router.min.js"
                                                                        , "~/LibreriasJS/jquery-1.11.3.min.js"
                                                                       ));

            bundles.Add(new ScriptBundle("~/bundles/frontend").IncludeDirectory("~/Frontend/", "*.js", true));

        }
    }
}

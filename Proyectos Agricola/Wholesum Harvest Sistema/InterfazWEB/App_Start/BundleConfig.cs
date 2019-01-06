using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Optimization;

namespace InterfazWEB.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css").Include("~/frontend/styles/css/*.css"));
            bundles.Add(new ScriptBundle("~/bundles/librerias").Include("~/frontend/libs/angular.min.js"
                                                                        , "~/frontend/libs/angular-ui-router.min.js"
                                                                        , "~/frontend/libs/jquery-1.11.3.min.js"
                                                                       ));

            bundles.Add(new ScriptBundle("~/bundles/frontend").IncludeDirectory("~/frontend/js/", "*.js", true));

        }
    }
}

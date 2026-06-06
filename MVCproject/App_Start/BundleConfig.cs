using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MVCproject
{
    public class BundleConfig
    {
        // This method is used to register bundles
        public static void RegisterBundles(BundleCollection bundles)
        {
            // jQuery bundle
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.4.1.js"));

            // Bootstrap bundle
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.min.js"));

            // CSS bundle
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/Site.css"));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace GameTest.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/Scripts/jquery-{version}.js"));

         
            bundles.Add(new ScriptBundle("~/bundles/Content/Scripts").IncludeDirectory("~/Content/Scripts", "*.js", true));

            bundles.Add(new StyleBundle("~/bundles/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/components.css",
                      "~/Content/css/layout.css",
                      "~/Content/css/font-awesome.css",
                      "~/Content/css/custom.css",
                      "~/Content/css/bootstrap-table.min.css",
                      "~/Content/css/default.css"

                      ));
        }

    }
}
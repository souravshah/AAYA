﻿using System.Web;
using System.Web.Optimization;

namespace Govhack2016
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
              "~/Scripts/angular.min.js",
              "~/Scripts/angular-resource.min.js",
              "~/Scripts/angular-route.min.js",
              "~/Scripts/angular-animate.min.js",
              "~/Scripts/angular-sanitize.min.js",
              "~/Scripts/angular-ui-router.min.js",
              "~/Scripts/ng-infinite-scroll.js",
              "~/App_Scripts/app.js",
              "~/App_Scripts/route.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/default.css",
                      "~/Content/reset.css"));
        }
    }
}

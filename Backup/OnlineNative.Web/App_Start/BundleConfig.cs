using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace OnlineNative.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Content/bootstrapcss").Include(
                        "~/Content/css/bootstrap-theme.css",
                        "~/Content/css/bootstrap.css",
                        "~/Content/css/jumbotron.css"
                      ));
        }
    }
}
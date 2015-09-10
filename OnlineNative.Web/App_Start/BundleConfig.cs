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
            #region 脚本
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Scripts/bootstrap/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/templatemo").Include(
                      "~/Scripts/fresh/jquery.chocolat.js"
                      ));

            #endregion


            #region 样式
            bundles.Add(new StyleBundle("~/Content/bootstrapcss").Include(
                       "~/Content/css/bootstrap-theme.css",
                       "~/Content/css/bootstrap.min.css"
                     ));
            bundles.Add(new StyleBundle("~/Content/templatemo").Include(
                    "~/Content/css/style.css",
                    "~/Content/css/chocolat.css"
                  ));
            #endregion
        }
    }
}
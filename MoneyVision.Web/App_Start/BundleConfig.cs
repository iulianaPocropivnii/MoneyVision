using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MoneyVision.Web
{
     public static class BundleConfig
     {
          public static void RegisterBundles(BundleCollection bundles)
          {
               bundles.Add(new StyleBundle("~/bundles/css").Include(
                                                    "~/Content/bootstrap.css",
                                                    "~/Content/animate.css",
                                                    "~/Content/css/style.css",
                                                    "~/Content/css/main.css",
                                                    "~/Content/font-awesome.min.css"
                                                ));

               bundles.Add(new Bundle("~/bundles/bootstrap/js").Include(
                      "~/Content/js/main.js",
                      "~/Scripts/bootstrap.bundle.min.js"
                      )); ;


               BundleTable.EnableOptimizations = true;

          }
     }
}

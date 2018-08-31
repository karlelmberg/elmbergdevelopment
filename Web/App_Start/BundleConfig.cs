using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
            //    "~/Scripts/Lib/jquery/jquery-{version}.js",
            //    "~/Scripts/Lib/jquery/jquery.*",
            //    "~/Scripts/Lib/jquery/jquery-ui-{version}.js")
            //);

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                    "~/Static/js/components/angular/angular.js"
                ).IncludeDirectory("~/Static/js/angular", "*.js", true)
            );

            bundles.Add(new StyleBundle("~/bundles/css")
                //.Include("~/Static/css/bootstrap.css", new CssRewriteUrlTransform())
                //.Include("~/Static/css/bootstrap-responsive.css")
                //.Include("~/Static/css/media.css")
                //.Include("~/Static/css/style.css", new CssRewriteUrlTransform())
                //.Include("~/Static/css/editmode.css")            
                .Include("~/Static/css/index.css"));
        }
    }
}

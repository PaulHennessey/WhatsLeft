using System.Web;
using System.Web.Optimization;

namespace WhatsLeft
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery.ui.datepicker-en-GB.js",
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                      "~/Scripts/DataTables/jquery.dataTables.js",
                      "~/Scripts/DataTables/dataTables.bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/whatsleft").Include(
                      "~/Scripts/whatsleft.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/DataTables/css/jquery.dataTables.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-datepicker3.css",
                      "~/Content/site.css"));
        }
    }
}

using System.Web;
using System.Web.Optimization;

namespace TabletCollection
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/customscripts").Include(
                "~/Scripts/jquery-ui.js",
                "~/Scripts/Paging.js",
                "~/Content/Select2/js/select2.js",
               "~/Content/DataTables/datatables.js",
               "~/Content/bootstrap-toggle-master/js/bootstrap-toggle.js",
               "~/Content/JQueryDataTablesCheckBoxes/js/dataTables.checkboxes.js",
               "~/Scripts/Site.js"
                ));

            bundles.Add(new StyleBundle("~/Content/cssstyles").Include(
                      "~/Content/Flatly/bootstrap-flatly.css",
                      "~/Content/DataTables/datatables.css",
                      "~/Content/Select2/css/select2.css",
                      "~/Content/Select2/select2-bootstrap.css",
                      "~/Content/bootstrap-toggle-master/css/bootstrap-toggle.css",
                      "~/Content/JQueryDataTablesCheckBoxes/css/dataTables.checkboxes.css",
                      "~/Content/site.css"));
            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}

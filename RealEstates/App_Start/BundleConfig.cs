using System.Web;
using System.Web.Optimization;

namespace RealEstates
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/typeahead.bundle.js",
                        "~/Scripts/umd/popper.min.js",
                        "~/Scripts/bootstrap.bundle.min.js",
                        "~/Scripts/jquery.easing.min.js",
                        "~/Scripts/sb-admin.min.js",
                        "~/Scripts/vendor/chart.js/Chart.min.js",
                        "~/Scripts/DataTables/jquery.dataTables.min.js",
                        "~/Scripts/DataTables/dataTables.bootstrap4.min.js",
                        "~/Scripts/toastr.js",
                        "~/Scripts/ckeditor/ckeditor.js",
                        "~/Scripts/select2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lumen.min.css",
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/typeahead.css",
                      "~/Content/toastr.css",
                      "~/Content/Site.css",
                      "~/Content/css/select2.css"));
        }
    }
}

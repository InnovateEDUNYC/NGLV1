using System.Web.Optimization;
using Links;

namespace NGL.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Assets/Scripts/lib/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Assets/Scripts/lib/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                        "~/Assets/Scripts/lib/jquery-ui-1.11.0/jquery-ui.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Assets/Scripts/lib/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Assets/Scripts/lib/bootstrap.js",
                      "~/Assets/Scripts/lib/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Assets/Content/bootstrap.css",
                      "~/Assets/Content/site.css",
                      "~/Assets/Content/datepicker.css",
                      "~/Assets/Scripts/lib/jquery-ui-1.11.0/jquery-ui.css",
                      "~/Assets/Scripts/lib/jquery-ui-1.11.0/jquery-ui.structure.css",
                      "~/Assets/Scripts/lib/jquery-ui-1.11.0/jquery-ui.theme.css"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                 "~/Assets/Scripts/createNamespace.js",
                 "~/Assets/Scripts/lib/bootstrap-datepicker.js",
                 "~/Assets/Scripts/forms.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/views").Include(
                "~/Assets/Scripts/Views/Enrollment/enterProgramStatus.js",
                "~/Assets/Scripts/Views/Enrollment/createStudent.js",
                "~/Assets/Scripts/Views/Student/index.js",
                "~/Assets/Scripts/Views/Schedule/getSchedule.js",
                "~/Assets/Scripts/Views/Section/getSession.js"
                ));
        }
    }
}

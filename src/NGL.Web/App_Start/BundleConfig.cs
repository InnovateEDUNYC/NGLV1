using System.Web.Optimization;

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
                      "~/Assets/Content/BootstrapOverrides.css",
                      "~/Assets/Content/image.css",
                      "~/Assets/Content/button.css",
                      "~/Assets/Content/CheckboxesAndRadioButtons.css",
                      "~/Assets/Content/datepicker.css",
                      "~/Assets/Content/Attendance.css",
                      "~/Assets/Content/ViewAssessmentResults.css",
                      "~/Assets/Content/Tables.css",
                      "~/Assets/Content/Profile.css",
                      "~/Assets/Content/Assessment.css",
                      "~/Assets/Content/paddingAndMargins.css"));

           bundles.Add(new StyleBundle("~/Assets/Scripts/lib/jquery-ui-1.11.0/bundle").Include(
                          "~/Assets/Scripts/lib/jquery-ui-1.11.0/*.css"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                 "~/Assets/Scripts/createNamespace.js",
                 "~/Assets/Scripts/lib/bootstrap-datepicker.js",
                 "~/Assets/Scripts/forms.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/views").Include(
                "~/Assets/Scripts/Views/Shared/programStatus.js",
                "~/Assets/Scripts/Views/Shared/checkboxesAndRadioButtons.js",
                "~/Assets/Scripts/Views/Shared/enableEditMode.js",
                "~/Assets/Scripts/Views/Shared/editProfile.js",
                "~/Assets/Scripts/Views/Enrollment/enterProgramStatus.js",
                "~/Assets/Scripts/Views/Enrollment/createStudent.js",
                "~/Assets/Scripts/Views/Student/index.js",
                "~/Assets/Scripts/Views/Student/all.js",
                "~/Assets/Scripts/Views/Student/editBiographicalInfo.js",
                "~/Assets/Scripts/Views/Student/editStudentName.js",
                "~/Assets/Scripts/Views/Student/editParentInfo.js",
                "~/Assets/Scripts/Views/Student/editAcademicDetails.js",
                "~/Assets/Scripts/Views/Student/editProgramStatus.js",
                "~/Assets/Scripts/Views/Student/editHomeAddress.js",
                "~/Assets/Scripts/Views/Schedule/setSchedule.js",
                "~/Assets/Scripts/Views/Schedule/removeStudent.js",
                "~/Assets/Scripts/Views/Section/getCourse.js",
                "~/Assets/Scripts/Views/Shared/sessionAutocomplete.js",
                "~/Assets/Scripts/Views/Shared/sectionAutocomplete.js",
                "~/Assets/Scripts/Views/Assessment/result.js",
                "~/Assets/Scripts/Views/Attendance/take.js",
                "~/Assets/Scripts/Views/Shared/learningStandards.js",
                "~/Assets/Scripts/Views/Report/getGrades.js",
                "~/Assets/Scripts/Views/Shared/accordianArrows.js",
                "~/Assets/Scripts/Views/Shared/radioButtons.js",
                "~/Assets/Scripts/Views/Shared/parentCourseAutocomplete.js"
                ));
        }
    }
}

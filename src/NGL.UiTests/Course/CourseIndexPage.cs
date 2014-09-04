using System.Linq;
using NGL.Web.Models.Course;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Course
{
    public class CourseIndexPage : Page<IndexModel>
    {
        public CourseCreatePage GoToCreatePage()
        {
            return Navigate.To<CourseCreatePage>(By.LinkText("Create New Course"));
        }

        public bool CourseExists(CreateModel createModel)
        {
            var courseCodeExists =
                Find.Element(By.CssSelector("tr:last-of-type td.course-code")).Text.Equals(createModel.CourseCode);

            var courseTitleExists =
                Find.Element(By.CssSelector("tr:last-of-type td.course-title")).Text.Equals(createModel.CourseTitle);

            var courseDescriptionExists =
                Find.Element(By.CssSelector("tr:last-of-type td.course-description")).Text.Equals(createModel.CourseDescription);

            return courseCodeExists && courseTitleExists && courseDescriptionExists;
        }

        public int GetNumberOfCourses()
        {
            return Find.Elements(By.ClassName("delete-row-btn")).Count();
        }

        public CourseIndexPage GoDelete(string courseCode)
        {
            Execute.Script("$('[data-course=\"" + courseCode + "\"]').find('.delete-row-btn').click()");

            return this;
        }
    }
}
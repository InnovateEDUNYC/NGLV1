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
                Find.Element(By.CssSelector("tr:nth-child(2) td.course-code")).Text.Equals(createModel.CourseCode);

            var courseTitleExists =
                Find.Element(By.CssSelector("tr:nth-child(2) td.course-title")).Text.Equals(createModel.CourseTitle);

            var courseDescriptionExists =
                Find.Element(By.CssSelector("tr:nth-child(2) td.course-description")).Text.Equals(createModel.CourseDescription);

            return courseCodeExists && courseTitleExists && courseDescriptionExists;
        }

    }
}
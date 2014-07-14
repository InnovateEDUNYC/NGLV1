using NGL.Web.Models.Course;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Pages
{
    public class CourseCreatePage : Page<CreateModel>
    {
        public CourseIndexPage CreateCourse()
        {
            return Navigate.To<CourseIndexPage>(By.ClassName("btn"));
        }
    }
}
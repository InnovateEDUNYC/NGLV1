using NGL.Web.Models.Course;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Course
{
    public class CourseCreatePage : Page<CreateModel>
    {
        public CourseIndexPage CreateCourse(CreateModel createCourseModel)
        {
            Input.Model(createCourseModel);
            return Navigate.To<CourseIndexPage>(By.ClassName("btn"));
        }
    }
}
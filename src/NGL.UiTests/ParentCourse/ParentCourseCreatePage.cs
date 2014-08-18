using NGL.Web.Models.ParentCourse;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.ParentCourse
{
    public class ParentCourseCreatePage : Page<CreateModel>
    {
        public ParentCourseIndexPage CreateParentCourse(CreateModel createParentCourseModel)
        {
            Input.Model(createParentCourseModel);
            return Navigate.To<ParentCourseIndexPage>(By.ClassName("btn"));   
        }
    }
}

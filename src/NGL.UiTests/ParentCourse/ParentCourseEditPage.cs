using System.Web.UI;
using NGL.Web.Models.ParentCourse;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.ParentCourse
{
    public class ParentCourseEditPage : Page<EditModel>
    {
        public ParentCourseIndexPage EditParentCourse(EditModel editParentCourseModel)
        {
            Input.Model(editParentCourseModel);
            return Navigate.To<ParentCourseIndexPage>(By.ClassName("btn")); 
        }
    }
}

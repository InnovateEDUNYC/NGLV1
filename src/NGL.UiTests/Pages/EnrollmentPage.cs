using NGL.Web.Models.Student;
using TestStack.Seleno.PageObjects;
using By = OpenQA.Selenium.By;

namespace NGL.UiTests.Pages
{
    class EnrollmentPage : Page<EnrollmentModel>
    {
        public StudentPage Enroll()
        {
            return Navigate.To<StudentPage>(By.ClassName("btn"));
        }
    }

}

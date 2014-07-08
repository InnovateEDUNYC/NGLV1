using NGL.Web.Models.Enrollment;
using NGL.Web.Models.Student;
using TestStack.Seleno.PageObjects;
using By = OpenQA.Selenium.By;

namespace NGL.UiTests.Pages
{
    class EnrollmentPage : Page<CreateStudentModel>
    {
        public StudentIndexPage Enroll()
        {
            return Navigate.To<StudentIndexPage>(By.ClassName("btn"));
        }
    }

}

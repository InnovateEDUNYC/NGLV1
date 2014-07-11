using NGL.Web.Models.Enrollment;
using TestStack.Seleno.PageObjects;
using By = OpenQA.Selenium.By;

namespace NGL.UiTests.Pages
{
    class EnrollmentPage : Page<CreateStudentModel>
    {
        public StudentIndexPage Enroll(CreateStudentModel createStudentModel)
        {
            Input.Model(createStudentModel);
            return Navigate.To<StudentIndexPage>(By.ClassName("btn"));
        }
    }
}

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
            Input.ReplaceInputValueWith("BirthDate", "12/12/12");

            return Navigate.To<StudentIndexPage>(By.ClassName("btn"));
        }
    }
}

using NGL.Web.Models.Enrollment;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Enrollment
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

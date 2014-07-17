using NGL.UiTests.Student;
using NGL.Web.Models.Student;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Enrollment
{
    class StudentIndexPage : Page<IndexModel>
    {
        public EnrollmentPage GoToEnroll()
        {
            return Navigate.To<EnrollmentPage>(By.LinkText("Enroll a Student"));
        }

        public ProfilePage GoToProfilePage(string studentUsi)
        {
            return Navigate.To<ProfilePage>(By.LinkText(studentUsi));
        }
    }
}

using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Pages
{
    class TopMenu : UiComponent
    {
        public SchoolPage GoToSchoolPage()
        {
            return Navigate.To<SchoolPage>(By.LinkText("School Info"));
        }

        public LoginPage GoToLoginPage()
        {
            return Navigate.To<LoginPage>(By.LinkText("Log in"));
        }

        public StudentIndexPage GoToStudentPage()
        {
            return Navigate.To<StudentIndexPage>(By.LinkText("Students"));
        }

        public Page LogOff()
        {
            return Navigate.To<Page>(By.LinkText("Log off"));
        }
    }
}
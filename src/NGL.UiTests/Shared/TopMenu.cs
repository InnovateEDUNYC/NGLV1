using NGL.UiTests.Account;
using NGL.UiTests.Enrollment;
using NGL.UiTests.School;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Shared
{
    class TopMenu : UiComponent
    {
        public SchoolPage GoToSchoolPage()
        {
            return Navigate.To<SchoolPage>(By.LinkText("NGL Platform"));
        }

        public LoginPage GoToLoginPage()
        {
            return Navigate.To<LoginPage>(By.LinkText("Log in"));
        }

        public StudentIndexPage GoToStudentsPage()
        {
            return Navigate.To<StudentIndexPage>(By.LinkText("Profile"));
        }

        public SchedulingPage GoToSchedulingPage()
        {
            Find.Element(By.LinkText("Planning")).Click();
            return Navigate.To<SchedulingPage>(By.LinkText("Course Generation"));
        }

        public EnrollmentPage GoToEnrollmentPage()
        {
            Find.Element(By.LinkText("Planning")).Click();
            return Navigate.To<EnrollmentPage>(By.LinkText("Enrollment"));
        }

        public HomePage LogOff()
        {
            return Navigate.To<HomePage>(By.LinkText("Log off"));
        }

        public ManageUserPage GoToManageUserPage()
        {
            return Navigate.To<ManageUserPage>(By.Id("manageUser"));
        }

        public bool IsLoggedOn
        {
            get { return Find.OptionalElement(By.Id("manageUser")) != null; }
        }
    }
}
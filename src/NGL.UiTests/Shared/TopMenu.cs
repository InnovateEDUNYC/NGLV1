using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Pages
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

        public SessionCreatePage GoToSchedulingPage()
        {
            Find.Element(By.LinkText("Planning")).Click();
            return Navigate.To<SessionCreatePage>(By.LinkText("Scheduling"));
        }

        public CourseCreatePage GoToCourseCreatePage()
        {
            Find.Element(By.LinkText("Planning")).Click();
            return Navigate.To<CourseCreatePage>(By.LinkText("Courses"));
        }

        public Page LogOff()
        {
            return Navigate.To<Page>(By.LinkText("Log off"));
        }
    }
}
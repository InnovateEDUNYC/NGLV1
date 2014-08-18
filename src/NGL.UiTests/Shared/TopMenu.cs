using NGL.UiTests.Account;
using NGL.UiTests.Assessment;
using NGL.UiTests.Attendance;
using NGL.UiTests.Enrollment;
using NGL.UiTests.School;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Shared
{
    public class TopMenu : UiComponent
    {
        public SchoolPage GoToSchoolPage()
        {
            return Navigate.To<SchoolPage>(By.ClassName("navbar-brand"));
        }

        public LoginPage GoToLoginPage()
        {
            return Navigate.To<LoginPage>(By.LinkText("Log in"));
        }

        public StudentIndexPage GoToStudentsPage()
        {
            return Navigate.To<StudentIndexPage>(By.LinkText("Profile"));
        }

        public CourseGenerationPage GoToCourseGenerationPage()
        {
            Find.Element(By.LinkText("Planning")).Click();
            return Navigate.To<CourseGenerationPage>(By.LinkText("Course Generation"));
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

        public ChangePasswordPage GoToChangePasswordPage()
        {
            return Navigate.To<ChangePasswordPage>(By.Id("changePassword"));
        }

        public bool IsLoggedOn
        {
            get { return Find.OptionalElement(By.Id("changePassword")) != null; }
        }

        public UsersPage GoToUsersPage()
        {
            return Navigate.To<UsersPage>(By.LinkText("Users"));
        }

        public AssessmentIndexPage GoToAssessmentIndexPage()
        {
            return Navigate.To<AssessmentIndexPage>(By.LinkText("Assessment"));
        }

        public TakeAttendancePage GoToTakeAttendancePage()
        {
            return Navigate.To<TakeAttendancePage>(By.LinkText("Attendance"));
        }
    }
}
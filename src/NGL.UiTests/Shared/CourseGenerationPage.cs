using NGL.UiTests.ClassPeriod;
using NGL.UiTests.Course;
using NGL.UiTests.Location;
using NGL.UiTests.Session;
using OpenQA.Selenium;
using Page = TestStack.Seleno.PageObjects.Page;

namespace NGL.UiTests.Shared
{
    public class CourseGenerationPage : Page
    {

        public SessionIndexPage GoToSessionIndexPage()
        {
            return Navigate.To<SessionIndexPage>(By.LinkText("Sessions"));
        }

        public CourseIndexPage GoToCourseIndexPage()
        {
            return Navigate.To<CourseIndexPage>(By.LinkText("Courses"));
        }

        public ClassPeriodIndexPage GoToClassPeriodIndexPage()
        {
            return Navigate.To<ClassPeriodIndexPage>(By.LinkText("Periods"));
        }

        public LocationIndexPage GoToLocationIndexPage()
        {
            return Navigate.To<LocationIndexPage>(By.LinkText("Classrooms"));
        }

//        public SectionCreatePage GoToSectionCreatePage()
//        {
//            return Navigate.To<SectionCreatePage>(By.LinkText("Create Section"));
//        }
    }
}

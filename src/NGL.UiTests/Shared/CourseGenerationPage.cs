using NGL.UiTests.ClassPeriod;
using NGL.UiTests.Course;
using NGL.UiTests.Location;
using NGL.UiTests.ParentCourse;
using NGL.UiTests.Section;
using NGL.UiTests.Session;
using OpenQA.Selenium;
using Page = TestStack.Seleno.PageObjects.Page;

namespace NGL.UiTests.Shared
{
    public class CourseGenerationPage : Page
    {

        public SessionIndexPage GoToSessionIndexPage()
        {
            return Navigate.To<SessionIndexPage>(By.LinkText("Sessions".ToUpper()));
        }

        public CourseIndexPage GoToCourseIndexPage()
        {
            return Navigate.To<CourseIndexPage>(By.LinkText("Courses".ToUpper()));
        }

        public ClassPeriodIndexPage GoToClassPeriodIndexPage()
        {
            return Navigate.To<ClassPeriodIndexPage>(By.LinkText("Periods".ToUpper()));
        }

        public LocationIndexPage GoToLocationIndexPage()
        {
            return Navigate.To<LocationIndexPage>(By.LinkText("Classrooms".ToUpper()));
        }

        public SectionIndexPage GoToSectionIndexPage()
        {
            return Navigate.To<SectionIndexPage>(By.LinkText("Sections".ToUpper()));
        }

        public ParentCourseIndexPage GoToParentCourseIndexPage()
        {
            return Navigate.To<ParentCourseIndexPage>(By.LinkText("Parent Courses".ToUpper()));
        }
    }
}

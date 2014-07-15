using NGL.UiTests.Session;
using OpenQA.Selenium;
using Page = TestStack.Seleno.PageObjects.Page;

namespace NGL.UiTests.Shared
{
    class SchedulingPage : Page
    {

        public SessionIndexPage GoToSessionIndexPage()
        {
            return Navigate.To<SessionIndexPage>(By.LinkText("Sessions"));
        }
    }
}

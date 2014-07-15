using NGL.Web.Models.Session;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Session
{
    public class SessionCreatePage : Page<CreateModel>
    {
        public SessionIndexPage CreateSession(CreateModel createSessionModel)
        {
            Input.Model(createSessionModel);
            return Navigate.To<SessionIndexPage>(By.ClassName("btn"));
        }
    }
}
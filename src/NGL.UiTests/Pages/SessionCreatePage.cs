using System.Web.UI;
using NGL.Web.Models.Session;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Pages
{
    public class SessionCreatePage : Page<CreateModel>
    {
        public SessionIndexPage CreateSession()
        {
            return Navigate.To<SessionIndexPage>(By.ClassName("btn"));
        }
    }
}
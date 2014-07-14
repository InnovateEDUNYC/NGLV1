using NGL.Web.Models.Account;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Shared
{
    class LoginPage : Page<LoginViewModel>
    {
        public HomePage Login(LoginViewModel model)
        {
            Input.Model(model);
            return Navigate.To<HomePage>(By.ClassName("btn"));
        }
    }
}

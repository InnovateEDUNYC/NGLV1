using NGL.UiTests.Shared;
using NGL.Web.Models.Account;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Account
{
    class LoginPage : Page<LoginModel>
    {
        public HomePage Login(LoginModel model)
        {
            Input.Model(model);
            return Navigate.To<HomePage>(By.ClassName("btn"));
        }
    }
}

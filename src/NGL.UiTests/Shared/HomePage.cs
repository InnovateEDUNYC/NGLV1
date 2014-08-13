using NGL.Web.Models.Account;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Shared
{
    public class HomePage : Page
    {
        public TopMenu TopMenu
        {
            get { return GetComponent<TopMenu>(); }
        }

        public HomePage Login(LoginModel login)
        {
            return TopMenu.GoToLoginPage().Login(login);
        }
    }
}
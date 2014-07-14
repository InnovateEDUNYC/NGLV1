using NGL.Web.Models.Account;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Pages
{
    class HomePage : Page
    {
        public TopMenu TopMenu
        {
            get { return GetComponent<TopMenu>(); }
        }

        public HomePage Login(LoginViewModel login)
        {
            return TopMenu.GoToLoginPage().Login(login);
        }
    }
}
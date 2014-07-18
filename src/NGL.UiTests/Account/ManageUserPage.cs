using NGL.UiTests.Shared;
using NGL.Web.Models.Account;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Account
{
    class ManageUserPage : Page<ManageUserViewModel>
    {
        public ManageUserPage ChangePassword(ManageUserViewModel model)
        {
            Input.Model(model);
            return Navigate.To<ManageUserPage>(By.ClassName("btn"));
        }

        public TopMenu Menu
        {
            get { return GetComponent<TopMenu>(); }
        }

        public bool HasSuccessMessage()
        {
            return Find.Element(By.ClassName("text-success")).Text == "Your password has been changed.";
        }
    }
}
using NGL.UiTests.Shared;
using NGL.Web.Models.Account;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Account
{
    public class ChangePasswordPage : Page<ChangePasswordModel>
    {
        public ChangePasswordPage ChangePassword(ChangePasswordModel model)
        {
            Input.Model(model);
            return Navigate.To<ChangePasswordPage>(By.ClassName("btn"));
        }

        public TopMenu Menu
        {
            get { return GetComponent<TopMenu>(); }
        }

        public bool HasSuccessMessage()
        {
            return Find.Element(By.Id("password-edit-success")).Text.Contains("Your password has been changed.");
        }
    }
}
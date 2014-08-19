using NGL.Web.Models.Account;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Shared
{
    public class AddUserPage: Page<AddUserModel>
    {
        public UsersPage Register(AddUserModel addUserModel)
        {
            Input.Model(addUserModel);
            if (addUserModel.CriminalBackgroundCheck)
            {
                Input.TickCheckbox(m => m.CriminalBackgroundCheck, true);
            }
            if (addUserModel.Fingerprinted)
            {
                Input.TickCheckbox(m => m.Fingerprinted, true);
            }

            return Navigate.To<UsersPage>(By.Id("registerButton"));
        }
    }
}
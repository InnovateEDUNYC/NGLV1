using NGL.Web.Models.Account;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Shared
{
    class AddUserPage: Page<AddUserModel>
    {
        public UsersPage Register(AddUserModel addUserModel)
        {
            Input.Model(addUserModel);
            return Navigate.To<UsersPage>(By.Id("registerButton"));
        }
    }
}
using NGL.Web.Models.Account;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;
using TestStack.Seleno.PageObjects.Actions;

namespace NGL.UiTests.Shared
{
    class UsersPage: Page
    {
        public AddUserPage GoToAddUserPage()
        {
            return Navigate.To<AddUserPage>(By.LinkText("Add User"));
        }

        public TableReader<UserModel> GetUsers()
        {
            return TableFor<UserModel>("users");
        }
    }
}
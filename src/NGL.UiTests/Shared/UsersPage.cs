using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Shared
{
    class UsersPage: Page
    {
        public AddUserPage GoToAddUserPage()
        {
            return Navigate.To<AddUserPage>(By.LinkText("Add User"));
        }

        public IList<string> GetUsers()
        {
            return Find.Elements(By.ClassName("userName")).Select(e => e.Text).ToList();
        }
    }
}
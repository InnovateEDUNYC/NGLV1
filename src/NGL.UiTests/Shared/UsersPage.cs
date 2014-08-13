using Humanizer;
using NGL.Web.Models.Account;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;
using TestStack.Seleno.PageObjects.Actions;

namespace NGL.UiTests.Shared
{
    public class UsersPage: Page
    {
        public AddUserPage GoToAddUserPage()
        {
            return Navigate.To<AddUserPage>(By.LinkText("Add User"));
        }

        public TableReader<UserModel> GetUsers()
        {
            return TableFor<UserModel>("users");
        }

        public bool UserExists(AddUserModel user)
        {
            if (!Find.Element(By.CssSelector("tr:last-of-type td.username")).Text.Equals(user.Username))
                return false;

            if (!Find.Element(By.CssSelector("tr:last-of-type td.role")).Text.Equals(user.Role.Humanize()))
                return false;

            if (!Find.Element(By.CssSelector("tr:last-of-type td.firstname")).Text.Equals(user.FirstName))
                return false;

            if (!Find.Element(By.CssSelector("tr:last-of-type td.lastname")).Text.Equals(user.LastName))
                return false;

            if (!Find.Element(By.CssSelector("tr:last-of-type td.staffusi")).Text.Equals(user.StaffUSI.ToString()))
                return false;

            return true;

        }
    }
}
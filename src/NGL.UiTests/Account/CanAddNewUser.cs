using System.Linq;
using NGL.UiTests.Shared;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models.Account;
using Ninject;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace NGL.UiTests.Account
{
    [Story(
        AsA = "Master Admin",
        IWant = "to add new user",
        SoThat = "school staff can login to the website")]
    public class CanAddNewUser
    {
        private HomePage _homePage;
        private UsersPage _usersPage;
        private readonly AddUserModel _newUser = new AddUserModel
            {
                Username = "NewUser",
                Password = "NewPassword",
                ConfirmPassword = "NewPassword"
            };

        void GivenIHaveLoggedInAsAMasterAdmin()
        {
            _homePage = Host
                .Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserJohnSmith.ViewModel);
        }

        void WhenINavigateToUsersManagerPage()
        {
            _usersPage = _homePage.TopMenu.GoToUsersPage();
        }

        void AndWhenICreateANewUserAsAdmin()
        {
            var repo = Host.Locator.Get<IGenericRepository>();
            var role = repo.GetAll<AspNetRole>().FirstOrDefault(r => r.Name == "Admin");
            _newUser.Role = role.Id;
            _usersPage.GoToAddUserPage().Register(_newUser);
        }

        void ThenTheUserAppearsOnTheUserLists()
        {
            _usersPage.GetUsers().ShouldContain(_newUser.Username);
        }

        void AndTheUserCanLogin()
        {
            _homePage.TopMenu.LogOff().Login(new LoginModel {Username = _newUser.Username, Password = _newUser.Password});
            _homePage.TopMenu.IsLoggedOn.ShouldBe(true);
        }

        [Fact]
        public void Verify()
        {
            this.BDDfy();
        }
    }
}

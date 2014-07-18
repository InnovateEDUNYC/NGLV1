using NGL.UiTests.Shared;
using NGL.Web.Models.Account;
using Shouldly;
using Xunit;

namespace NGL.UiTests.Account
{
    public class CanChangePassword
    {
        [Fact]
        public void Verify()
        {
            const string newPassword = "234234";
            var manageUserViewModel = new ManageUserViewModel
            {
                OldPassword = ObjectMother.JohnSmith.Password,
                NewPassword = newPassword,
                ConfirmPassword= newPassword,
            };

            var manageUserPage = Host
                .Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.JohnSmith.ViewModel)
                .TopMenu
                .GoToManageUserPage()
                .ChangePassword(manageUserViewModel);

            manageUserPage.HasSuccessMessage().ShouldBe(true);
        }

    }
}

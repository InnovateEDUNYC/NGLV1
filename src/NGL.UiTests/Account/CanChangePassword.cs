﻿using NGL.UiTests.Shared;
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
            const string oldPassword = "123123";
            const string username = "HellenSmith";
            var changePasswordModel = new ChangePasswordModel
            {
                CurrentPassword = oldPassword,
                NewPassword = newPassword,
                ConfirmPassword= newPassword,
            };

            var manageUserPage = Host
                .Instance
                .NavigateToInitialPage<HomePage>()
                .Login(new LoginModel {Username = username, Password = oldPassword})
                .TopMenu
                .GoToChangePasswordPage()
                .ChangePassword(changePasswordModel);

            manageUserPage.HasSuccessMessage().ShouldBe(true);

            manageUserPage
                .Menu
                .LogOff()
                .Login(new LoginModel {Username = username, Password = newPassword})
                .TopMenu
                .IsLoggedOn
                .ShouldBe(true);
        }
    }
}

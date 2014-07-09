using System;
using NGL.UiTests.Pages;
using NGL.Web.Models.Account;
using NGL.Web.Models.Session;
using Shouldly;
using TestStack.BDDfy;
using Xunit;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests
{
    [Story(
        AsA = "As a school admin",
        IWant = "I want to create sessions for each school year",
        SoThat = "So that I can manage the courses offered in each section")]
    public class CanCreateSession
    {
        private HomePage _homePage;
        private SessionCreatePage _sessionCreatePage;
        private CreateModel _createSessionModel;
        private SessionIndexPage _sessionIndexPage;

        public void GivenIHaveLoggedIn()
        {
            _homePage = Host.Instance.NavigateToInitialPage<HomePage>();
            var loginPage = _homePage.TopMenu.GoToLoginPage();

            loginPage.Input.Model(
                new LoginViewModel
                {
                    UserName = ObjectMother.JohnSmith.Username,
                    Password = ObjectMother.JohnSmith.Password
                });

            _homePage = loginPage.Login();
        }

        public void AndGivenIAmOnTheCreateSessionPage()
        {
            _sessionIndexPage = _homePage.TopMenu.GoToSessionPage();
            _sessionCreatePage = _sessionIndexPage.GoToCreatePage();
        }

        public void WhenIHaveEnteredValidInputForAllFields()
        {
            _createSessionModel = new CreateModel()
            {
                Term = ObjectMother.Fall2014Semester.Term,
                SchoolYear = ObjectMother.Fall2014Semester.SchoolYear,
                BeginDate = ObjectMother.Fall2014Semester.BeginDate,
                EndDate = ObjectMother.Fall2014Semester.EndDate,
                TotalInstructionalDays = ObjectMother.Fall2014Semester.TotalInstructionalDays
            };

            _sessionCreatePage.Input.Model(_createSessionModel);
            _sessionIndexPage = _sessionCreatePage.CreateSession();
        }

        public void ThenANewSessionShouldBeDisplayedOnTheSessionIndexPage()
        {
            bool sessionExists = _sessionIndexPage.sessionExists(_createSessionModel);

            sessionExists.ShouldBe(true);
        }



        [Fact]
        public void ShouldCreateSession()
        {
            this.BDDfy();
        }
    }
}
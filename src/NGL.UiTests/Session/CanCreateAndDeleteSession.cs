using System;
using NGL.Tests.Builders;
using NGL.UiTests.Shared;
using NGL.Web;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Session;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace NGL.UiTests.Session
{
    [Story(
        AsA = "As a school admin",
        IWant = "I want to create and delete sessions for each school year",
        SoThat = "So that I can manage the courses offered in each section")]
    public class CanCreateAndDeleteSession
    {
        private HomePage _homePage;
        private CourseGenerationPage _courseGenerationPage;
        private CreateModel _createSessionModel;
        private SessionIndexPage _sessionIndexPage;
        private SessionCreatePage _sessionCreatePage;

        public void IHaveLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserMasterAdmin.ViewModel);
        }

        public void IAmOnTheCreateSessionPage()
        {
            _courseGenerationPage = _homePage.TopMenu.GoToCourseGenerationPage();
            _sessionCreatePage = _courseGenerationPage.GoToSessionIndexPage().GoToCreatePage();
        }

        public void IHaveEnteredValidInputForAllFields()
        {
            _createSessionModel = new SessionModelBuilder().Build();

            _sessionIndexPage = _sessionCreatePage.CreateSession(_createSessionModel);
        }

        public void ANewSessionShouldBeDisplayedOnTheSessionIndexPage()
        {
            _sessionIndexPage.SessionExists(_createSessionModel).ShouldBe(true);
        }

        public void IDeleteTheSession()
        {
            _sessionIndexPage.DeleteSession(_createSessionModel);
        }

        public void TheSessionShouldBeDeleted()
        {
            _sessionIndexPage.SessionExists(_createSessionModel).ShouldBe(false);
        }

        [Fact]
        public void ShouldCreateSession()
        {
            this.Given(_ => IHaveLoggedIn())
                .And(_ => IAmOnTheCreateSessionPage())
                .When(_ => IHaveEnteredValidInputForAllFields())
                .Then(_ => ANewSessionShouldBeDisplayedOnTheSessionIndexPage())
                .When(_ => IDeleteTheSession())
                .Then(_ => TheSessionShouldBeDeleted())
                .BDDfy();
        }
    }
}
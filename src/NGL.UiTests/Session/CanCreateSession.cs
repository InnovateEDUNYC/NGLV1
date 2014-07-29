using NGL.UiTests.Shared;
using NGL.Web.Models.Session;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace NGL.UiTests.Session
{
    [Story(
        AsA = "As a school admin",
        IWant = "I want to create sessions for each school year",
        SoThat = "So that I can manage the courses offered in each section")]
    public class CanCreateSession
    {
        private HomePage _homePage;
        private SchedulingPage _schedulingPage;
        private CreateModel _createSessionModel;
        private SessionIndexPage _sessionIndexPage;
        private SessionCreatePage _sessionCreatePage;

        public void GivenIHaveLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserJohnSmith.ViewModel);
        }

        public void AndGivenIAmOnTheCreateSessionPage()
        {
            _schedulingPage = _homePage.TopMenu.GoToSchedulingPage();
            _sessionCreatePage = _schedulingPage.GoToSessionIndexPage().GoToCreatePage();
        }

        public void WhenIHaveEnteredValidInputForAllFields()
        {
            _createSessionModel = new CreateModel
            {
                Term = ObjectMother.Spring2038Semester.Term,
                SchoolYear = ObjectMother.Spring2038Semester.SchoolYear,
                BeginDate = ObjectMother.Spring2038Semester.BeginDate,
                EndDate = ObjectMother.Spring2038Semester.EndDate,
                TotalInstructionalDays = ObjectMother.Spring2038Semester.TotalInstructionalDays
            };

            _sessionIndexPage = _sessionCreatePage.CreateSession(_createSessionModel);
        }

        public void ThenANewSessionShouldBeDisplayedOnTheSessionIndexPage()
        {
            bool sessionExists = _sessionIndexPage.SessionExists(_createSessionModel);

            sessionExists.ShouldBe(true);
        }

        [Fact]
        public void ShouldCreateSession()
        {
            this.BDDfy();
        }
    }
}
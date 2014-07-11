using NGL.UiTests.Pages;
using NGL.Web.Models.Session;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

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
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.JohnSmith.ViewModel);
        }

        public void AndGivenIAmOnTheCreateSessionPage()
        {
            _sessionCreatePage = _homePage.TopMenu.GoToSchedulingPage();
        }

        public void WhenIHaveEnteredValidInputForAllFields()
        {
            _createSessionModel = new CreateModel
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
using NGL.Tests.Builders;
using NGL.UiTests.Shared;
using NGL.Web.Models.Assessment;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace NGL.UiTests.Assessment
{
    [Story(
        AsA = "As a teacher",
        IWant = "I want to create a formative assessment for a specific section",
        SoThat = "So that I can track student's progress over time"
        )]
    public class CanCreateAssessment
    {
        private HomePage _homePage;
        private AssessmentCreatePage _assessmentCreatePage;
        private CreateModel _createAssessmentModel;
        private AssessmentIndexPage _assessmentIndexPage;
        private EnterResultsModel _enterResultsModel;

        public void IHaveLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserJohnSmith.ViewModel);
        }

        public void IAmOnTheCreateAssessmentPage()
        {
            _assessmentCreatePage = _homePage.TopMenu.GoToAssessmentIndexPage().GoToCreatePage();
        }

        public void IHaveEnteredValidInputForAllFields()
        {
            _createAssessmentModel = new CreateAssessmentModelBuilder().Build();
            _assessmentIndexPage = _assessmentCreatePage.CreateAssessment(_createAssessmentModel);
        }

        public void ANewAssessmentShouldBeDisplayedOnTheAssessmentIndexPage()
        {
            var assessmentExists = _assessmentIndexPage.AssessmentExists(_createAssessmentModel);
            assessmentExists.ShouldBe(true);
        }

        public void IGoToTheResultsPageAndFillInValidResults()
        {
            var resultsPage = _assessmentIndexPage.GoToResultsPage();
            _enterResultsModel = new EnterResultsModelBuilder().Build();
            resultsPage.EnterResults(_enterResultsModel);
        }

        [Fact]
        public void ShouldCreateAssessment()
        {
            this.Given(_ => IHaveLoggedIn())
                .And(_ => IAmOnTheCreateAssessmentPage())
                .When(_ => IHaveEnteredValidInputForAllFields())
                .Then(_ => ANewAssessmentShouldBeDisplayedOnTheAssessmentIndexPage())
                .When(_=> IGoToTheResultsPageAndFillInValidResults())
                .BDDfy();
        }
    }
}

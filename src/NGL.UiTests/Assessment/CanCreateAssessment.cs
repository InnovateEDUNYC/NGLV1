using NGL.Tests.Builders;
using NGL.UiTests.Shared;
using NGL.Web.Models.Assessment;
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
        private CreateAssessmentModel _createAssessmentModel;

        public void IHaveLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserJohnSmith.ViewModel);
        }

        public void IAmOnTheCreateAssessmentPage()
        {
            _assessmentCreatePage = _homePage.TopMenu.GoToAssessmentCreatePage();
        }

        public void IHaveEnteredValidInputForAllFields()
        {
            _createAssessmentModel = new CreateAssessmentModelBuilder().Build();
            _assessmentCreatePage.CreateAssessment(_createAssessmentModel);
        }

        [Fact]
        public void ShouldScheduleStudent()
        {
            this.Given(_ => IHaveLoggedIn())
                .And(_ => IAmOnTheCreateAssessmentPage())
                .When(_ => IHaveEnteredValidInputForAllFields())
                .BDDfy();
        }

    }
}

using NGL.Tests.Builders;
using NGL.UiTests.Shared;
using NGL.Web.Models.Schedule;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace NGL.UiTests.Schedule
{
    [Story(
        AsA = "As a school admin",
        IWant = "I want to assign a student to class sections",
        SoThat = "So I can later take attendance and enter assessment"
        )]
    public class CanScheduleStudent
    {
        private HomePage _homePage;
        private SchedulePage _schedulePage;
        private Web.Data.Entities.Student _student;
        private SetModel _setModel;

        public void AdminHasLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserJohnSmith.ViewModel);
        }

        public void GoToTheSchedulePage()
        {
            _student = new StudentBuilder().Build();
            _schedulePage = _homePage.TopMenu.GoToStudentsPage().GoToProfilePage().GoToSchedulePage();
        }

        public void HaveEnteredValidInputForAllFields()
        {
            _setModel = new SetScheduleModelBuilder().WithStudent(_student).Build();
            _schedulePage.AddStudentToSection(_setModel);
        }
        public void ShouldSeeTheSectionAddedToListOfSections()
        {
            var sectionIsVisible = _schedulePage.SectionIsVisible();

            sectionIsVisible.ShouldBe(true);
        }

        [Fact]
        public void ShouldScheduleStudent()
        {
            this.Given(_ => AdminHasLoggedIn())
                .And(_ => GoToTheSchedulePage())
                .When(_ => HaveEnteredValidInputForAllFields())
                .Then(_ => ShouldSeeTheSectionAddedToListOfSections())
                .BDDfy();
        }
    }
}

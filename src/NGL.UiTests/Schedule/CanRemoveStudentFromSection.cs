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
        IWant = "I want to remove a student from a section",
        SoThat = "So I can schedule to appropriate sections"
        )]
    public class CanRemoveStudentFromSection
    {
        private HomePage _homePage;
        private SchedulePage _schedulePage;
        private Web.Data.Entities.Student _student;
        private SetModel _setModelToBeRemoved;

        public void IHaveLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserJohnSmith.ViewModel);
        }

        public void IAmOnTheSchedulePage()
        {
            _student = new StudentBuilder().Build();
            _schedulePage = _homePage.TopMenu.GoToStudentsPage().GoToProfilePage().GoToSchedulePage();
        }

        public void IAssignMultipleSectionsToTheStudent()
        {
            _schedulePage.AddStudentToSection(new SetScheduleModelBuilder().WithStudent(_student).Build());
            _setModelToBeRemoved = new SetScheduleModelBuilder().WithStudent(_student).WithSectionId(10).Build();
            _schedulePage.AddStudentToSection(_setModelToBeRemoved);
        }

        public void IRemoveOneSection()
        {
            _schedulePage.RemoveSection(_setModelToBeRemoved.SectionId);
        }

        public void IShouldNotSeeTheRemovedSectionInTheListOfSections()
        {
            var sections = _schedulePage.GetSections();
            sections.Contains(_setModelToBeRemoved.SectionId.ToString()).ShouldBe(false);
        }

        [Fact]
        public void ShouldScheduleStudent()
        {
            this.Given(_ => IHaveLoggedIn())
                .And(_ => IAmOnTheSchedulePage())
                .And(_ => IAssignMultipleSectionsToTheStudent())
                .When(_ => IRemoveOneSection())
                .Then(_ => IShouldNotSeeTheRemovedSectionInTheListOfSections())
                .BDDfy();
        }
    }
}

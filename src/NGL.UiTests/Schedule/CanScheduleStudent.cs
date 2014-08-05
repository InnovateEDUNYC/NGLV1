using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
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

        public void IHaveEnteredValidInputForAllFields()
        {
            _setModel = new SetScheduleModelBuilder().WithStudent(_student).Build();
            _schedulePage.AddStudentToSection(_setModel);
        }
        public void IShouldSeeTheSectionAddedToListOfSections()
        {
            var sectionIsVisible = _schedulePage.SectionIsVisible();

            sectionIsVisible.ShouldBe(true);
        }

        [Fact]
        public void ShouldScheduleStudent()
        {
            this.Given(_ => IHaveLoggedIn())
                .And(_ => IAmOnTheSchedulePage())
                .When(_ => IHaveEnteredValidInputForAllFields())
                .Then(_ => IShouldSeeTheSectionAddedToListOfSections())
                .BDDfy();
        }

        
    }
}

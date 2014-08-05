using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using NGL.UiTests.Shared;
using NGL.Web.Models.Schedule;
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

        public void IHaveLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserJohnSmith.ViewModel);
        }

        public void IAmOnTheSchedulePage()
        {
            _schedulePage = _homePage.TopMenu.GoToStudentsPage().GoToProfilePage("999").GoToSchedulePage();
        }

//        public void IHaveEnteredValidInputForAllFields()
//        {
//            _student = new StudentBuilder().B
//            _setModel = SetModel.CreateNewWith()
//        }


        [Fact]
        public void ShouldScheduleStudent()
        {
            this.BDDfy();
        }
    }
}

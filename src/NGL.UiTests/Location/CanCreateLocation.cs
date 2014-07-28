using NGL.UiTests.Shared;
using Shouldly;
using TestStack.BDDfy;
using Xunit;
using CreateModel = NGL.Web.Models.Location.CreateModel;

namespace NGL.UiTests.Location
{
    [Story(
        AsA = "As a school admin",
        IWant = "I want to create locations",
        SoThat = "So that I know what are the different class rooms"
        )]
    public class CanCreateLocation
    {
        private HomePage _homePage;
        private CourseGenerationPage _courseGenerationPage;
        private LocationCreatePage _locationCreatePage;
        private CreateModel _locationCreateModel;
        private LocationIndexPage _locationIndexPage;

        public void GivenIHaveLoggedIn()
        {
            _homePage = Host.Instance
           .NavigateToInitialPage<HomePage>()
           .Login(ObjectMother.UserJohnSmith.ViewModel); 
        }

        public void AndGivenIAmOnTheCreateLocationPage()
        {
            _courseGenerationPage = _homePage.TopMenu.GoToCourseGenerationPage();
            _locationCreatePage = _courseGenerationPage.GoToLocationIndexPage().GoToCreatePage();
        }

        public void WhenIHaveEnteredValidInputForAllFields()
        {
            _locationCreateModel = new CreateModel
            {
                ClassroomIdentificationCode = ObjectMother.RoomA101.ClassRoomIdentificationCode,
                MaximumNumberOfSeats = ObjectMother.RoomA101.MaximumNumberOfSeats,
                OptimalNumberOfSeats = ObjectMother.RoomA101.OptimalNumberOfSeats
            };

            _locationIndexPage = _locationCreatePage.CreateLocation(_locationCreateModel);
        }

        public void ThenANewLocationShouldBeDisplayedOnTheLocationIndexPage()
        {
            bool locationExists = _locationIndexPage.LocationExists(_locationCreateModel);
            locationExists.ShouldBe(true);
        }


        [Fact]
        public void ShouldCreateLocation()
        {
            this.BDDfy();
        }
    }
}

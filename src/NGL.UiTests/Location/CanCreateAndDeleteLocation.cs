using NGL.Tests.Location;
using NGL.UiTests.Shared;
using Shouldly;
using TestStack.BDDfy;
using Xunit;
using CreateModel = NGL.Web.Models.Location.CreateModel;

namespace NGL.UiTests.Location
{
    [Story(
        AsA = "As a school admin",
        IWant = "I want to create and delete locations",
        SoThat = "So that I know what are the different class rooms"
        )]
    public class CanCreateAndDeleteLocation
    {
        private HomePage _homePage;
        private CourseGenerationPage _courseGenerationPage;
        private LocationCreatePage _locationCreatePage;
        private CreateModel _locationCreateModel;
        private LocationIndexPage _locationIndexPage;

        public void IHaveLoggedIn()
        {
            _homePage = Host.Instance
           .NavigateToInitialPage<HomePage>()
           .Login(ObjectMother.UserJohnSmith.ViewModel); 
        }

        public void IAmOnTheCreateLocationPage()
        {
            _courseGenerationPage = _homePage.TopMenu.GoToCourseGenerationPage();
            _locationCreatePage = _courseGenerationPage.GoToLocationIndexPage().GoToCreatePage();
        }

        public void IHaveEnteredValidInputForAllFields()
        {
            _locationCreateModel = new CreateLocationModelBuilder().Build();
            _locationIndexPage = _locationCreatePage.CreateLocation(_locationCreateModel);
        }

        public void ANewLocationShouldBeDisplayedOnTheLocationIndexPage()
        {
            var locationExists = _locationIndexPage.LocationExists(_locationCreateModel);
            locationExists.ShouldBe(true);
        }


        private void IDeleteALocation()
        {
            _locationIndexPage.Delete(_locationCreateModel);
        }

        private void TheLocationShouldNotBeDisplayed()
        {
            _locationIndexPage.LocationExists(_locationCreateModel).ShouldBe(false);
        }

        [Fact]
        public void ShouldCreateAndDeleteLocation()
        {
            this.Given(_ => IHaveLoggedIn())
                .And(_ => IAmOnTheCreateLocationPage())
                .When(_ => IHaveEnteredValidInputForAllFields())
                .Then(_ => ANewLocationShouldBeDisplayedOnTheLocationIndexPage())
                .When(_ => IDeleteALocation())
                .Then(_ => TheLocationShouldNotBeDisplayed())
                .BDDfy();
        }
    }
}

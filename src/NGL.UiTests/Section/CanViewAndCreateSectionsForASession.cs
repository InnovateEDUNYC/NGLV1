using NGL.UiTests.Session;
using NGL.UiTests.Shared;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace NGL.UiTests.Section
{
    [Story(
        AsA = "As a school admin",
        IWant = "I want to see a list of the terms and school year",
        SoThat = "so that I can click on a term and add/view sections")]
    public class CanViewAndCreateSectionsForASession
    {
        private HomePage _homePage;
        private SessionIndexPage _sessionIndexPage;
        private SectionsForSessionPage _sectionsForSessionPage;
        private SectionCreatePage _sectionCreatePage;

        public void IHaveLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserJohnSmith.ViewModel);
        }
        public void IAmOnTheSessionIndexPage()
        {
            _sessionIndexPage = _homePage.TopMenu.GoToCourseGenerationPage().GoToSessionIndexPage();
        }

        public void IChooseToViewSectionsForFallSemester()
        {
            _sectionsForSessionPage = _sessionIndexPage.ViewSectionsFor("Fall Semester");
        }

        public void FiveCoursesShouldBeDisplayedOnThePage()
        {
            _sectionsForSessionPage.GetCourseCount().ShouldBe(5);
        }

        public void FirstCourseShouldHaveSections()
        {
            _sectionsForSessionPage.GetSectionCountForFirstCourse().ShouldBeGreaterThan(0);
        }
        public void IChooseToCreateNewSection()
        {
            _sectionCreatePage = _sectionsForSessionPage.GoToCreateSectionPage();
        }

        public void IShouldSeeFall2014SelectedByDefault()
        {
            _sectionCreatePage.GetSession().ShouldBe("Fall 2014");
        }

        [Fact]
        public void ShouldViewAndCreateSectionsForASession()
        {
            this.Given(_ => IHaveLoggedIn())
                .And(_ => IAmOnTheSessionIndexPage())
                .When(_ => IChooseToViewSectionsForFallSemester())
                .Then(_ => FiveCoursesShouldBeDisplayedOnThePage())
                .Then(_ => FirstCourseShouldHaveSections())
                .When(_ => IChooseToCreateNewSection())
                .Then(_ => IShouldSeeFall2014SelectedByDefault())
                .BDDfy();
        }
    }
}

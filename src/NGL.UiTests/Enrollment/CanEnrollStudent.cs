using NGL.UiTests.Shared;
using NGL.UiTests.Student;
using NGL.Web.Models.Enrollment;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace NGL.UiTests.Enrollment
{
    [Story(
        AsA = "As an operations associate",
        IWant = "I want to enter biographical information in student profile",
        SoThat = "So that I can have a record for each student"
        )]
    public class CanEnrollStudent
    {
        private HomePage _homePage;
        private EnrollmentPage _enrollmentPage;
        private StudentIndexPage _studentIndexPage;
        private ProfilePage _profilePage;
        private CreateStudentModel _createStudentModel;
        private CreateParentModel _createParentModel;

        public void GivenIHaveLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserJohnSmith.ViewModel);
        }

        public void AndGivenIAmOnTheEnrollPage()
        {
            _enrollmentPage = _homePage.TopMenu.GoToEnrollmentPage();
        }

        public void WhenIHaveEnteredValidInputForAllFields()
        {
            _createParentModel = new CreateParentModel
            {
                FirstName = ObjectMother.StudentJanesDad.FirstName,
                LastName = ObjectMother.StudentJanesDad.LastName,
                Sex = ObjectMother.StudentJanesDad.Sex,
                RelationshipToStudent = ObjectMother.StudentJanesDad.RelationshipToStudent,
                MakeThisPrimaryContact = ObjectMother.StudentJanesDad.MakeThisPrimaryContact,
                TelephoneNumber = ObjectMother.StudentJanesDad.TelephoneNumber,
                EmailAddress = ObjectMother.StudentJanesDad.EmailAddress,
                SameAddressAsStudent = ObjectMother.StudentJanesDad.SameAddressAsStudent
            };

            _createStudentModel = new CreateStudentModel
            {
                StudentUsi = ObjectMother.StudentJane.StudentUsi,
                FirstName = ObjectMother.StudentJane.FirstName,
                LastName = ObjectMother.StudentJane.LastName,
                Sex = ObjectMother.StudentJane.Sex,
                BirthDate = ObjectMother.StudentJane.BirthDate,
                HispanicLatinoEthnicity = ObjectMother.StudentJane.HispanicLatinoEthnicity,
                Race = ObjectMother.StudentJane.Race,
                Address = ObjectMother.StudentJane.Address,
                Address2 = ObjectMother.StudentJane.Address2,
                City = ObjectMother.StudentJane.City,
                State = ObjectMother.StudentJane.State,
                PostalCode = ObjectMother.StudentJane.PostalCode,
                HomeLanguage = ObjectMother.StudentJane.HomeLanguage,
                FirstParent = _createParentModel
            };

            _studentIndexPage = _enrollmentPage.Enroll(_createStudentModel);
        }

        public void AndWhenIViewTheStudentProfile()
        {
            var studentUsi = _createStudentModel.StudentUsi.ToString();
            _profilePage = _studentIndexPage.GoToProfilePage(studentUsi);
        }

        public void ThenIShouldBeAbleToViewTheStudenInfo()
        {   
            var allFieldsExist = _profilePage.AllFieldsExist(_createStudentModel);
            allFieldsExist.ShouldBe(true);
        }


        [Fact]
        public void ShouldEnrollStudent()
        {
            this.BDDfy();
        }

    }
}

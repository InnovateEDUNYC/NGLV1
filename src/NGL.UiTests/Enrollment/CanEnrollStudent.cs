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
        private ProfilePage _profilePage;
        private ProgramStatusPage _programStatusPage;
        private CreateStudentModel _createStudentModel;
        private CreateParentModel _createParentModel;
        private AcademicDetailPage _academicDetailPage;

        public void IHaveLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserJohnSmith.ViewModel);
        }

        public void IAmOnTheEnrollPage()
        {
            _enrollmentPage = _homePage.TopMenu.GoToEnrollmentPage();
        }

        public void IHaveEnteredValidInputForAllFields()
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
                SameAddressAsStudent = ObjectMother.StudentJanesDad.SameAddressAsStudent,
                Address = ObjectMother.StudentJanesDad.Address,
                Address2 = ObjectMother.StudentJanesDad.Address2,
                City = ObjectMother.StudentJanesDad.City,
                State = ObjectMother.StudentJanesDad.State,
                PostalCode = ObjectMother.StudentJanesDad.PostalCode
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

            _academicDetailPage = _enrollmentPage.Enroll(_createStudentModel);
        }

        private void IShouldArriveOnTheAcademicDetailPage()
        {
            _academicDetailPage.IsTitleCorrect().ShouldBe(true);
        }
        private void IHaveInputAcademicDetails()
        {
            var academicDetailModel = new AcademicDetailModel
            {
                Reading = ObjectMother.JanesAcademicDetails.Reading,
                Writing = ObjectMother.JanesAcademicDetails.Writing,
                Math = ObjectMother.JanesAcademicDetails.Math,
                AnticipatedGrade = ObjectMother.JanesAcademicDetails.AnticipatedGrade,
                SchoolYear = ObjectMother.JanesAcademicDetails.SchoolYear,
                PerformanceHistory = ObjectMother.JanesAcademicDetails.PerformanceHistory,
                PerformanceHistoryFile = ObjectMother.JanesAcademicDetails.PerformanceHistoryFile
            };

            _programStatusPage = _academicDetailPage.InputDetails(academicDetailModel);
        }

        private void IShouldArriveOnTheProgramStatusPage()
        {
            _programStatusPage.IsTitleCorrect().ShouldBe(true);
        }
        private void IHaveInputProgramStatus()
        {
            var programStatusModel = new EnterProgramStatusModel
            {
                TestingAccommodation = ObjectMother.JanesProgramStatus.TestingAccommodation,
                TestingAccommodationFile = ObjectMother.JanesProgramStatus.TestingAccommodationFile,
                BilingualProgram = ObjectMother.JanesProgramStatus.BilingualProgram,
                EnglishAsSecondLanguage = ObjectMother.JanesProgramStatus.EnglishAsSecondLanguage,
                FoodServiceEligibilityStatus = ObjectMother.JanesProgramStatus.FoodServiceEligibilityStatus,
                Gifted = ObjectMother.JanesProgramStatus.Gifted,
                SpecialEducation = ObjectMother.JanesProgramStatus.SpecialEducation,
                SpecialEducationFile = ObjectMother.JanesProgramStatus.SpecialEducationFile,
                McKinneyVento = ObjectMother.JanesProgramStatus.McKinneyVento,
                McKinneyVentoFile = ObjectMother.JanesProgramStatus.McKinneyVentoFile,
                TitleParticipation = ObjectMother.JanesProgramStatus.TitleParticipation,
                TitleParticipationFile = ObjectMother.JanesProgramStatus.TitleParticipationFile,
            };
            _profilePage = _programStatusPage.InputProgramStatus(programStatusModel);
        }
        public void IShouldBeAbleToViewTheStudenInfo()

        {
            var allFieldsExist = _profilePage.AllFieldsExist(_createStudentModel);
            allFieldsExist.ShouldBe(true);
        }
        [Fact]
        public void ShouldEnrollStudent()
        {
            this.Given(_ => IHaveLoggedIn())
                .And(_ => IAmOnTheEnrollPage())
                .When(_ => IHaveEnteredValidInputForAllFields())
                .Then(_ => IShouldArriveOnTheAcademicDetailPage())
                .When(_ => IHaveInputAcademicDetails())
                .Then(_ => IShouldArriveOnTheProgramStatusPage())
                .When(_ => IHaveInputProgramStatus())
                .Then(_ => IShouldBeAbleToViewTheStudenInfo())
                .BDDfy();
        }
    }
}

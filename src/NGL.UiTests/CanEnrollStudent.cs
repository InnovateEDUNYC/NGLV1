using NGL.UiTests.Pages;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Account;
using NGL.Web.Models.Enrollment;
using Shouldly;
using Xunit;

namespace NGL.UiTests
{
    public class CanEnrollStudent
    {
        private CreateStudentModel _createStudentModel;

        [Fact]
        public void Verify()
        {
            var homePage = Host.Instance.NavigateToInitialPage<HomePage>();
            var loginPage = homePage.TopMenu.GoToLoginPage();

            Login(loginPage);

            homePage = loginPage.Login();
            var studentPage = homePage.TopMenu.GoToStudentPage();

            var parentEnrollmentInfoModel = InitializeParentEnrollmentModel();

            InitializeCreateStudentModel();

            var enrollmentPage = studentPage.GoToEnroll();
            enrollmentPage.Input.Model(_createStudentModel);
            enrollmentPage.InputParentInfoModel(parentEnrollmentInfoModel);

            studentPage = enrollmentPage.Enroll();

            studentPage.LastUsiInTheList.ShouldBe(_createStudentModel.StudentUsi.ToString());

            var usiStringOfStudent = studentPage.LastUsiInTheList;
            
            usiStringOfStudent.ShouldBe(_createStudentModel.StudentUsi.ToString());

        }

        private void Login(LoginPage loginPage)
        {
            loginPage.Input.Model(
                new LoginViewModel
                {
                    UserName = ObjectMother.JohnSmith.Username,
                    Password = ObjectMother.JohnSmith.Password
                });
        }

        private void InitializeCreateStudentModel()
        {
            _createStudentModel = new CreateStudentModel
            {
                StudentUsi = 20, //change every test run
                FirstName = "Joe",
                LastName = "ZZ",
                SexTypeEnum = SexTypeEnum.Male,
                OldEthnicityTypeEnum = OldEthnicityTypeEnum.AmericanIndianOrAlaskanNative,
                StreetNumberName = "123 Oak St",
                ApartmentRoomSuiteNumber = "1A",
                City = "Springfield",
                StateAbbreviationTypeEnum = StateAbbreviationTypeEnum.CA,
                PostalCode = "6000",
                HispanicLatinoEthnicity = true,
                LanguageDescriptorEnum = LanguageDescriptorEnum.English,
            };
        }

        private ParentEnrollmentInfoModel InitializeParentEnrollmentModel()
        {
            var parentEnrollmentInfoModel = new ParentEnrollmentInfoModel
            {
                ParentFirstName = "Michael",
                ParentLastName = "Smith",
                ParentUsi = 3,//change every test run
                SexTypeEnum = SexTypeEnum.Male
            };
            return parentEnrollmentInfoModel;
        }
    }
}

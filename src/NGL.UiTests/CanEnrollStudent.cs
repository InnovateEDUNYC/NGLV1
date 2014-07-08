using System;
using NGL.UiTests.Pages;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Account;
using NGL.Web.Models.Enrollment;
using NGL.Web.Models.Student;
using Shouldly;
using TestStack.Seleno.Configuration;
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

            loginPage.Input.Model(
                new LoginViewModel
                {
                    UserName = ObjectMother.JohnSmith.Username,
                    Password = ObjectMother.JohnSmith.Password
                });

            homePage = loginPage.Login();
            var studentPage = homePage.TopMenu.GoToStudentPage();
            
            _createStudentModel = new CreateStudentModel()
            {
                StudentUsi = 18, //change every test run
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
                LanguageDescriptorEnum = LanguageDescriptorEnum.English
            };

            var enrollmentPage = studentPage.GoToEnroll();
            enrollmentPage.Input.Model(_createStudentModel);
            enrollmentPage.Input.ReplaceInputValueWith("BirthDate", "12/12/12");
            studentPage = enrollmentPage.Enroll();

            studentPage.LastUsiInTheList.ShouldBe(_createStudentModel.StudentUsi.ToString());

            var usiStringOfStudent = studentPage.LastUsiInTheList;
            
            usiStringOfStudent.ShouldBe(_createStudentModel.StudentUsi.ToString());

        }
    }
}

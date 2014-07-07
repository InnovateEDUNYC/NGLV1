using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGL.UiTests.Pages;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Account;
using NGL.Web.Models.Student;
using OpenQA.Selenium;
using Shouldly;
using Xunit;

namespace NGL.UiTests
{
    public class CanEnrollStudent
    {
        private EnrollmentModel _enrollmentModel;

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
            
            _enrollmentModel = new EnrollmentModel()
            {
                StudentUsi = 1232196,
                FirstName = "Joe",
                LastSurname = "ZZ",
                SexTypeEnum = SexTypeEnum.Male,
                OldEthnicityTypeEnum = OldEthnicityTypeEnum.AmericanIndianOrAlaskanNative,
                StreetNumberName = "123 Oak St",
                ApartmentRoomSuiteNumber = "1A",
                City = "Springfield",
                StateAbbreviationTypeEnum = StateAbbreviationTypeEnum.CA,
                PostalCode = "6000",
                BirthDate = new DateTime(2000,1,11),
                HispanicLatinoEthnicity = true,
                LanguageDescriptorEnum = LanguageDescriptorEnum.English
            };

            var enrollmentPage = studentPage.GoToEnroll();
            enrollmentPage.Input.Model(_enrollmentModel);
            studentPage = enrollmentPage.Enroll();


            var usiStringOfStudent = studentPage.GetUsiStringOfLastStudentOnTable();
            
            usiStringOfStudent.ShouldBe(_enrollmentModel.StudentUsi.ToString());


        }
    }
}

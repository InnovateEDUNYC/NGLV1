using NGL.UiTests.Pages;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Enrollment;
using Shouldly;
using Xunit;

namespace NGL.UiTests
{
    public class CanEnrollStudent
    {
        [Fact]
        public void Verify()
        {
            var homePage = Host.Instance.NavigateToInitialPage<HomePage>().Login(ObjectMother.JohnSmith.ViewModel);
            var studentPage = homePage.TopMenu.GoToStudentPage();
            var createStudentModel = GetCreateStudentModel();

            studentPage = studentPage.GoToEnroll().Enroll(createStudentModel);

            studentPage.LastUsiInTheList.ShouldBe(createStudentModel.StudentUsi.ToString());

            var usiStringOfStudent = studentPage.LastUsiInTheList;
            usiStringOfStudent.ShouldBe(createStudentModel.StudentUsi.ToString());

        }

        private CreateStudentModel GetCreateStudentModel()
        {
            return new CreateStudentModel
            {
                StudentUsi = 123240, //change every test run
                FirstName = "Joe",
                LastName = "ZZ",
                Sex = SexTypeEnum.Male,
                Race = RaceTypeEnum.AmericanIndianAlaskanNative,
                Address = "123 Oak St",
                Address2 = "1A",
                City = "Springfield",
                State = StateAbbreviationTypeEnum.CA,
                PostalCode = "6000",
                HispanicLatinoEthnicity = true,
                HomeLanguage = LanguageDescriptorEnum.English,
                ParentEnrollmentInfoModel = GetParentEnrollmentModel()
            };
        }

        private ParentEnrollmentInfoModel GetParentEnrollmentModel()
        {
            var parentEnrollmentInfoModel = new ParentEnrollmentInfoModel
            {
                FirstName = "Jan",
                LastName = "Smith",
                Sex = SexTypeEnum.Male,
                RelationshipToStudent = RelationTypeEnum.MothersCivilPartner,
                MakeThisPrimatyContact = true,
                TelephoneNumber = "123-4567",
                EmailAddress = "jan@civilpartner.me",
            };
            return parentEnrollmentInfoModel;
        }
    }
}

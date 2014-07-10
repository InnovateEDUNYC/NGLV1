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
                StudentUsi = 12,
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
                ParentEnrollmentInfoModel = GetParentEnrollmentModel()
            };
        }

        private ParentEnrollmentInfoModel GetParentEnrollmentModel()
        {
            var parentEnrollmentInfoModel = new ParentEnrollmentInfoModel
            {
                FirstName = "Jan",
                LastName = "Smith",
                SexTypeEnum = SexTypeEnum.Male,
                RelationshipToStudent = RelationTypeEnum.MothersCivilPartner
            };
            return parentEnrollmentInfoModel;
        }
    }
}

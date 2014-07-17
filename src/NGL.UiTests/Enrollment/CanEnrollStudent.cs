using System;
using NGL.UiTests.Shared;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Enrollment;
using Shouldly;
using Xunit;

namespace NGL.UiTests.Enrollment
{
    public class CanEnrollStudent
    {
        [Fact]
        public void Verify()
        {
            var createStudentModel = GetCreateStudentModel();

            var studentPage = Host
                .Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.JohnSmith.ViewModel)
                .TopMenu
                .GoToStudentsPage()
                .GoToEnroll()
                .Enroll(createStudentModel);

            studentPage.LastUsiInTheList.ShouldBe(createStudentModel.StudentUsi.ToString());
        }

        private CreateStudentModel GetCreateStudentModel()
        {
            return new CreateStudentModel
            {
                StudentUsi = 123240,
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
                FirstParent = GetParentEnrollmentModel(),
                BirthDate = new DateTime(1999, 1, 5)
            };
        }

        private CreateParentModel GetParentEnrollmentModel()
        {
            var parentEnrollmentInfoModel = new CreateParentModel
            {
                FirstName = "Jan",
                LastName = "Smith",
                Sex = SexTypeEnum.Male,
                RelationshipToStudent = RelationTypeEnum.MothersCivilPartner,
                MakeThisPrimaryContact = true,
                TelephoneNumber = "123-4567",
                EmailAddress = "jan@civilpartner.me",
                SameAddressAsStudent = true
            };
            return parentEnrollmentInfoModel;
        }
    }
}

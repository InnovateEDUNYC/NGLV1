using System.Linq;
using Humanizer;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Student;
using Shouldly;
using Xunit;

namespace NGL.Tests.Student
{
    public class StudentToProfileModelMapperTest
    {
        [Fact]
        public void ShouldMapStudentToProfileModel()
        {
            var student = StudentFactory.CreateStudentWithOneParent();
            var parent = student.StudentParentAssociations.First().Parent;
            var profileModel = new ProfileModel();

            var mapper = new StudentToProfileModelMapper(new ParentToProfileParentModelMapper(), new StudentToAcademicDetailsMapper());
            mapper.Map(student, profileModel);

            NativeStudentPropertiesShouldBeMapped(student, profileModel);
            NativeParentPropertiesShouldBeMapped(parent, profileModel.ProfileParentModel);
            StudentParentAssociationShouldBeMapped(student, profileModel);
        }

        [Fact]
        public void ShouldMapStudentToProfileModelWithDifferentParentAddress()
        {
            var parent = ParentFactory.CreateParentWithAddress();
            var student = StudentFactory.CreateStudentWithOneParent(parent, false);
            var profileModel = new ProfileModel();

            var mapper = new StudentToProfileModelMapper(new ParentToProfileParentModelMapper(), new StudentToAcademicDetailsMapper());
            mapper.Map(student, profileModel);

            NativeStudentPropertiesShouldBeMapped(student, profileModel);
            NativeParentPropertiesShouldBeMapped(parent, profileModel.ProfileParentModel);
            ParentAddressShouldBeMapped(parent, profileModel);
            StudentParentAssociationShouldBeMapped(student, profileModel);
        }

        [Fact]
        public void ShouldMapStudentToProfileModelWithMultipleParents()
        {
            var student = StudentFactory.CreateStudentWithTwoParents();
            var firstParent = student.StudentParentAssociations.First().Parent;
            var secondParent = student.StudentParentAssociations.ElementAt(1).Parent;
            var profileModel = new ProfileModel();

            var mapper = new StudentToProfileModelMapper(new ParentToProfileParentModelMapper(), new StudentToAcademicDetailsMapper());
            mapper.Map(student, profileModel);

            NativeStudentPropertiesShouldBeMapped(student, profileModel);
            NativeParentPropertiesShouldBeMapped(firstParent, profileModel.ProfileParentModel);
            NativeParentPropertiesShouldBeMapped(secondParent, profileModel.SecondProfileParentModel);
            StudentParentAssociationShouldBeMapped(student, profileModel);
        }

        [Fact]
        public void ShouldMapStudentToProfileModelWithAcademicDetails()
        {
            var student = StudentFactory.CreateStudentWithOneParent();
            var profileModel = new ProfileModel();

            var mapper = new StudentToProfileModelMapper(new ParentToProfileParentModelMapper(), new StudentToAcademicDetailsMapper());
            mapper.Map(student, profileModel);

            NativeStudentPropertiesShouldBeMapped(student, profileModel);

            var studentAcademicDetail = student.StudentAcademicDetails.First();
            profileModel.AcademicDetail.ReadingScore.ShouldBe(studentAcademicDetail.ReadingScore);
            profileModel.AcademicDetail.WritingScore.ShouldBe(studentAcademicDetail.WritingScore);
            profileModel.AcademicDetail.MathScore.ShouldBe(studentAcademicDetail.MathScore);
            profileModel.AcademicDetail.PerformanceHistoryFileUrl.ShouldBe(
                studentAcademicDetail.PerformanceHistoryFileUrl);
        }

        private static void NativeStudentPropertiesShouldBeMapped(Web.Data.Entities.Student student, ProfileModel profileModel)
        {
            profileModel.StudentUsi.ShouldBe(student.StudentUSI);
            profileModel.FirstName.ShouldBe(student.FirstName);
            profileModel.LastName.ShouldBe(student.LastSurname);
            profileModel.BirthDate.ShouldBe(student.BirthDate);

            var studentRace = student.StudentRaces.First();
            profileModel.Race.ShouldBe(((RaceTypeEnum) studentRace.RaceTypeId).Humanize());
            profileModel.HispanicLatinoEthnicity.ShouldBe(student.HispanicLatinoEthnicity);
            profileModel.Sex.ShouldBe(((SexTypeEnum) student.SexTypeId).Humanize());

            var studentProfileHomeLanguage = profileModel.HomeLanguage;
            studentProfileHomeLanguage.ShouldBe(((LanguageDescriptorEnum) student.StudentLanguages.First().LanguageDescriptorId).Humanize());
        }

        private static void NativeParentPropertiesShouldBeMapped(Parent parent, ProfileParentModel profileParentModel)
        {
            profileParentModel.FirstName.ShouldBe(parent.FirstName);
            profileParentModel.LastName.ShouldBe(parent.LastSurname);
            profileParentModel.Sex.ShouldBe(((SexTypeEnum) parent.SexTypeId).Humanize());
            profileParentModel.TelephoneNumber.ShouldBe(parent.ParentTelephones.First().TelephoneNumber);
            profileParentModel.EmailAddress.ShouldBe(parent.ParentElectronicMails.First().ElectronicMailAddress);
        }

        private static void StudentParentAssociationShouldBeMapped(Web.Data.Entities.Student student, ProfileModel profileModel)
        {
            var profileParentModel = profileModel.ProfileParentModel;
            var studentParentAssociation = student.StudentParentAssociations.First();
            profileParentModel.Relationship.ShouldBe(
                ((RelationTypeEnum)studentParentAssociation.RelationTypeId).Humanize());

            profileParentModel.SameAddressAsStudent.ShouldBe(studentParentAssociation.LivesWith);
        }

        private static void ParentAddressShouldBeMapped(Parent parent, ProfileModel profileModel)
        {
            var profileParentAddressModel = profileModel.ProfileParentModel.ProfileParentAddressModel;
            var parentHomeAddress = parent.ParentAddresses.First();

            profileParentAddressModel.Address.ShouldBe(parentHomeAddress.StreetNumberName);
            profileParentAddressModel.Address2.ShouldBe(parentHomeAddress.ApartmentRoomSuiteNumber);
            profileParentAddressModel.City.ShouldBe(parentHomeAddress.City);
            profileParentAddressModel.State.ShouldBe(
                ((StateAbbreviationTypeEnum) parentHomeAddress.StateAbbreviationTypeId).Humanize());
            profileParentAddressModel.PostalCode.ShouldBe(parentHomeAddress.PostalCode);
        }
    }
}

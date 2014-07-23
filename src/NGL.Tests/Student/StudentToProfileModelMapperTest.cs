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

            var mapper = new StudentToProfileModelMapper(
                new StudentToProfileHomeLanguageModelMapper(), 
                new ParentToProfileParentModelMapper()
            );
            mapper.Map(student, profileModel);

            NativeStudentPropertiesShouldBeMapped(profileModel, student);
            NativeParentPropertiesShouldBeMapped(profileModel.ProfileParentModel, parent);
            StudentParentAssociationShouldBeMapped(profileModel, student);
        }

        [Fact]
        public void ShouldMapStudentToProfileModelWithDifferentParentAddress()
        {
            var parent = ParentFactory.CreateParentWithAddress();
            var student = StudentFactory.CreateStudentWithOneParent(parent, false);
            var profileModel = new ProfileModel();

            var mapper = new StudentToProfileModelMapper(
                new StudentToProfileHomeLanguageModelMapper(),
                new ParentToProfileParentModelMapper()
            );
            mapper.Map(student, profileModel);

            NativeStudentPropertiesShouldBeMapped(profileModel, student);
            NativeParentPropertiesShouldBeMapped(profileModel.ProfileParentModel, parent);
            ParentAddressShouldBeMapped(profileModel, parent);
            StudentParentAssociationShouldBeMapped(profileModel, student);
        }

        [Fact]
        public void ShouldMapStudentToProfileModelWithMultipleParents()
        {
            var student = StudentFactory.CreateStudentWithTwoParents();
            var firstParent = student.StudentParentAssociations.First().Parent;
            var secondParent = student.StudentParentAssociations.ElementAt(1).Parent;
            firstParent.FirstName = "linda";
            var profileModel = new ProfileModel();

            var mapper = new StudentToProfileModelMapper(
                new StudentToProfileHomeLanguageModelMapper(),
                new ParentToProfileParentModelMapper()
            );
            mapper.Map(student, profileModel);

            NativeStudentPropertiesShouldBeMapped(profileModel, student);
            NativeParentPropertiesShouldBeMapped(profileModel.ProfileParentModel, firstParent);
            NativeParentPropertiesShouldBeMapped(profileModel.SecondProfileParentModel, secondParent);
            StudentParentAssociationShouldBeMapped(profileModel, student);
        }

        private static void NativeParentPropertiesShouldBeMapped(ProfileParentModel profileParentModel, Parent parent)
        {
            profileParentModel.FirstName.ShouldBe(parent.FirstName);
            profileParentModel.LastName.ShouldBe(parent.LastSurname);
            profileParentModel.Sex.ShouldBe(((SexTypeEnum) parent.SexTypeId).Humanize());
            profileParentModel.TelephoneNumber.ShouldBe(parent.ParentTelephones.First().TelephoneNumber);
            profileParentModel.EmailAddress.ShouldBe(parent.ParentElectronicMails.First().ElectronicMailAddress);
        }

        private static void ParentAddressShouldBeMapped(ProfileModel profileModel, Parent parent)
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

        private static void NativeStudentPropertiesShouldBeMapped(ProfileModel profileModel, Web.Data.Entities.Student student)
        {
            profileModel.StudentUsi.ShouldBe(student.StudentUSI);
            profileModel.FirstName.ShouldBe(student.FirstName);
            profileModel.LastName.ShouldBe(student.LastSurname);
            profileModel.BirthDate.ShouldBe(student.BirthDate);

            var studentRace = student.StudentRaces.First();
            profileModel.Race.ShouldBe(((RaceTypeEnum) studentRace.RaceTypeId).Humanize());
            profileModel.HispanicLatinoEthnicity.ShouldBe(student.HispanicLatinoEthnicity);
            profileModel.Sex.ShouldBe(((SexTypeEnum) student.SexTypeId).Humanize());

            var studentProfileHomeLanguage = profileModel.HomeLanguage.HomeLanguage;
            studentProfileHomeLanguage.ShouldBe(((LanguageDescriptorEnum) student.StudentLanguages.First().LanguageDescriptorId).Humanize());
        }

        private static void StudentParentAssociationShouldBeMapped(ProfileModel profileModel, Web.Data.Entities.Student student)
        {
            var profileParentModel = profileModel.ProfileParentModel;
            var studentParentAssociation = student.StudentParentAssociations.First();
            profileParentModel.Relationship.ShouldBe(
                ((RelationTypeEnum)studentParentAssociation.RelationTypeId).Humanize());

            profileParentModel.SameAddressAsStudent.ShouldBe(studentParentAssociation.LivesWith);
        }
    }
}

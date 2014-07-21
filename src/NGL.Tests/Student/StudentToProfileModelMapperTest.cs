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
            var profileModel = new ProfileModel();

            var mapper = new StudentToProfileModelMapper(
                new StudentToProfileHomeLanguageModelMapper(), 
                new StudentToProfileParentModelMapper()
            );
            mapper.Map(student, profileModel);

            profileModel.StudentUsi.ShouldBe(StudentFactory.StudentUsi);
            profileModel.FirstName.ShouldBe(StudentFactory.FirstName);
            profileModel.LastName.ShouldBe(StudentFactory.LastName);
            profileModel.BirthDate.ShouldBe(StudentFactory.BirthDate);
            profileModel.Race.ShouldBe(((RaceTypeEnum) StudentFactory.Race).Humanize());
            profileModel.HispanicLatinoEthnicity.ShouldBe(StudentFactory.HispanicLatinoEthnicity);
            profileModel.Sex.ShouldBe(((SexTypeEnum) StudentFactory.Sex).Humanize());

            var studentProfileHomeLanguages = profileModel.ProfileHomeLanguageModel.HomeLanguages;
            studentProfileHomeLanguages.First().ShouldBe(
                ((LanguageDescriptorEnum) StudentLanguageFactory.LanguageDescriptorId).Humanize());

            var profileParentModel = profileModel.ProfileParentModel;
            profileParentModel.FirstName.ShouldBe(ParentFactory.FirstName);
            profileParentModel.LastName.ShouldBe(ParentFactory.LastName);
            profileParentModel.Sex.ShouldBe(((SexTypeEnum) ParentFactory.Sex).Humanize());
            profileParentModel.TelephoneNumber.ShouldBe(ParentFactory.PhoneNumber);
            profileParentModel.EmailAddress.ShouldBe(ParentFactory.Email);
            profileParentModel.RelationshipToStudent.ShouldBe(
                ((RelationTypeEnum) StudentFactory.PrimaryParentRelationType).Humanize());
            profileParentModel.SameAddressAsStudent.ShouldBe(StudentFactory.LivesWithPrimaryParent);
        }

    }
}

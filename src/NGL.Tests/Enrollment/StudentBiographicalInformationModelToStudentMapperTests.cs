using System;
using System.Linq;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Enrollment;
using Shouldly;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class StudentBiographicalInformationModelToStudentMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var studentBiographicalInfo = new StudentBiographicalInformationModelBuilder().Build();
            var mapper = new EditStudentBiographicalInfoModelToStudentMapper();
            var student = new StudentBuilder().Build();
            mapper.Map(studentBiographicalInfo, student);

            student.BirthDate.ShouldBe(DateTime.Parse(studentBiographicalInfo.BirthDate));
            student.SexTypeId.ShouldBe((int)studentBiographicalInfo.Sex);
            student.HispanicLatinoEthnicity.ShouldBe(studentBiographicalInfo.HispanicLatinoEthnicity);
            student.StudentRaces.First().RaceTypeId.ShouldBe((int)studentBiographicalInfo.Race);

            const int languageDescriptorId = (int)LanguageDescriptorEnum.Spanish;

            student.StudentLanguages.First().LanguageDescriptorId.ShouldBe(languageDescriptorId);
            student.StudentLanguages.First()
                .StudentLanguageUses.First()
                .LanguageUseTypeId.ShouldBe((int)LanguageUseTypeEnum.Homelanguage);

            student.StudentLanguages.First()
                .StudentLanguageUses.First()
                .LanguageDescriptorId.ShouldBe(languageDescriptorId);
        }
    }
}

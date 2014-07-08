using System;
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
        public void ShouldMap()
        {
            var student = new Web.Data.Entities.Student
            {
                StudentUSI = 1789,
                FirstName = "Bob",
                LastSurname = "Jenkins",
                BirthDate = new DateTime(2000, 2, 2),
                OldEthnicityTypeId = (int?) OldEthnicityTypeEnum.BlackNotOfHispanicOrigin,
                HispanicLatinoEthnicity = true,
                SexTypeId = (int) SexTypeEnum.Male
            };
            var studentDetailsModel = new ProfileModel();

            var mapper = new StudentToProfileModelMapper();
            mapper.Map(student, studentDetailsModel);

            studentDetailsModel.FirstName.ShouldBe("Bob");
            studentDetailsModel.LastName.ShouldBe("Jenkins");
            studentDetailsModel.BirthDate.ShouldBe(new DateTime(2000, 2, 2));
            studentDetailsModel.Race.ShouldBe(OldEthnicityTypeEnum.BlackNotOfHispanicOrigin.Humanize());
            studentDetailsModel.HispanicLatinoEthnicity.ShouldBe(true);
            studentDetailsModel.Sex.ShouldBe(SexTypeEnum.Male.Humanize());
        }
    }
}

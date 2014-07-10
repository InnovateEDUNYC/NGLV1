using NGL.Web.Data.Entities;
using NGL.Web.Models.Enrollment;
using Shouldly;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class ParentEnrollmentInfoModelToParentMapperTest
    {
        [Fact]
        public void ShouldMap()
        {
            var mapper = new ParentEnrollmentInfoModelToParentMapper();
            var parentEnrollmentInfoModel = new ParentEnrollmentInfoModel
            {
                FirstName = "Cameron",
                LastName = "James",
                SexTypeEnum = SexTypeEnum.Male
            };

            var parent = new Parent();
            
            mapper.Map(parentEnrollmentInfoModel, parent);

            parent.FirstName.ShouldBe("Cameron");
            parent.LastSurname.ShouldBe("James");
            parent.SexTypeId.ShouldBe((int) SexTypeEnum.Male);
        }
    }
}
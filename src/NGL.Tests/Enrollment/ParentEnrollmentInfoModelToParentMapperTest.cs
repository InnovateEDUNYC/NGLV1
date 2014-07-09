using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;
using Shouldly;
using Xunit;

namespace NGL.Web.Models.Enrollment
{
    public class ParentEnrollmentInfoModelToParentMapperTest
    {
        [Fact]
        public void shouldMap()
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
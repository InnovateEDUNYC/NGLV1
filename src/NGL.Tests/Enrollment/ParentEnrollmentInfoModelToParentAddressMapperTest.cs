using NGL.Web.Data.Entities;
using NGL.Web.Models.Enrollment;
using NGL.Web.Models.Enrollment.Parent;
using Shouldly;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class ParentEnrollmentInfoModelToParentAddressMapperTest
    {
        [Fact]
        public void ShouldMap()
        {
            var parentAddressMapper = new ParentEnrollmentInfoModelToParentAddressMapper();
            var parentAddress = new ParentAddress();
            var parentEnrollmentInfoModel = SetUpParentEnrollmentInfoModel();

            parentAddressMapper.Map(parentEnrollmentInfoModel, parentAddress);

            parentAddress.City.ShouldBe("Seattle");
            parentAddress.StateAbbreviationTypeId.ShouldBe((int) StateAbbreviationTypeEnum.LA);
            parentAddress.PostalCode.ShouldBe("90210");
            parentAddress.StreetNumberName.ShouldBe("1600 Pennsylvania");
            parentAddress.ApartmentRoomSuiteNumber.ShouldBe("19th fl");
        }

        private static ParentEnrollmentInfoModel SetUpParentEnrollmentInfoModel()
        {
            return new ParentEnrollmentInfoModel
            {
                City = "Seattle",
                State = StateAbbreviationTypeEnum.LA,
                PostalCode = "90210",
                ParentAddress = "1600 Pennsylvania",
                Address2 = "19th fl"
            };
        }
    }
}

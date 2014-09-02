using System.Linq;
using NGL.Tests.Builders;
using NGL.Web.Models.Student;
using Shouldly;
using Xunit;

namespace NGL.Tests.Student
{
    public class EditParentAddressModelToParentAddressMapperTests
    {
        [Fact]
        public void ShouldUpdateParentAddress()
        {
            var source = new EditableParentAddressModelBuilder().Build();
            var target = new ParentBuilder().WithAddress().Build();
            var mapper = new EditableParentAddressModelToParentMapper();
            mapper.Map(source, target);

            target.ParentAddresses.First().StreetNumberName.ShouldBe(source.Address);
            target.ParentAddresses.First().ApartmentRoomSuiteNumber.ShouldBe(source.Address2);
            target.ParentAddresses.First().City.ShouldBe(source.City);
            target.ParentAddresses.First().PostalCode.ShouldBe(source.PostalCode);
            target.ParentAddresses.First().StateAbbreviationTypeId.ShouldBe((int)source.State);
        }

        [Fact]
        public void ShouldMakeNewParentAddressIfNoneExists()
        {
            var source = new EditableParentAddressModelBuilder().WithAddress("123 Model Rd").Build();
            var target = new ParentBuilder().Build();
            var mapper = new EditableParentAddressModelToParentMapper();
            mapper.Map(source, target);

            target.ParentAddresses.First().StreetNumberName.ShouldBe(source.Address);
            target.ParentAddresses.First().ApartmentRoomSuiteNumber.ShouldBe(source.Address2);
            target.ParentAddresses.First().City.ShouldBe(source.City);
            target.ParentAddresses.First().PostalCode.ShouldBe(source.PostalCode);
            target.ParentAddresses.First().StateAbbreviationTypeId.ShouldBe((int)source.State);
        }
    }
}

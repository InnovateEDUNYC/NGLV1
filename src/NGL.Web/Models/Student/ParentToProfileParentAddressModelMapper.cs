using System.Linq;
using Humanizer;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class ParentToProfileParentAddressModelMapper : MapperBase<Parent, ProfileParentAddressModel>
    {
        public override void Map(Parent source, ProfileParentAddressModel target)
        {
            var parentAddress = source.ParentAddresses.First();

            target.Address = parentAddress.StreetNumberName;
            target.Address2 = parentAddress.ApartmentRoomSuiteNumber;
            target.City = parentAddress.City;
            target.State = ((StateAbbreviationTypeEnum) parentAddress.StateAbbreviationTypeId).Humanize();
            target.PostalCode = parentAddress.PostalCode;
        }
    }
}
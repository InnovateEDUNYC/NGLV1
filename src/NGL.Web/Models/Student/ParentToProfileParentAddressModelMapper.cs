using System.Linq;
using Humanizer;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class ParentToProfileParentAddressModelMapper : MapperBase<Parent, EditableParentAddressModel>
    {
        public override void Map(Parent source, EditableParentAddressModel target)
        {
            var parentAddress = source.ParentAddresses.First();

            target.Address = parentAddress.StreetNumberName;
            target.Address2 = parentAddress.ApartmentRoomSuiteNumber;
            target.City = parentAddress.City;
            target.StateForDisplay = ((StateAbbreviationTypeEnum) parentAddress.StateAbbreviationTypeId).Humanize();
            target.State = (StateAbbreviationTypeEnum) parentAddress.StateAbbreviationTypeId;
            target.PostalCode = parentAddress.PostalCode;
        }
    }
}
using System.Linq;
using Humanizer;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class StudentToProfileParentAddressModelMapper : MapperBase<Data.Entities.Student, ProfileParentAddressModel>
    {
        public override void Map(Data.Entities.Student source, ProfileParentAddressModel target)
        {
            var parentAddress = source.StudentParentAssociations.First().Parent.ParentAddresses.First();

            target.Address = parentAddress.StreetNumberName;
            target.Address2 = parentAddress.ApartmentRoomSuiteNumber;
            target.City = parentAddress.City;
            target.State = ((StateAbbreviationTypeEnum) parentAddress.StateAbbreviationTypeId).Humanize();
            target.PostalCode = parentAddress.PostalCode;
        }
    }
}
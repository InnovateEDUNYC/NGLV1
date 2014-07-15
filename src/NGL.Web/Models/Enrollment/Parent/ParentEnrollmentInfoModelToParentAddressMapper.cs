using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment.Parent
{
    public class ParentEnrollmentInfoModelToParentAddressMapper : MapperBase<ParentEnrollmentInfoModel, ParentAddress>
    {
        private const int HomeAddressTypeId = (int)AddressTypeEnum.Home;

        public override void Map(ParentEnrollmentInfoModel source, ParentAddress target)
        {
            target.AddressTypeId = HomeAddressTypeId;
            target.StreetNumberName = source.ParentAddress;
            target.ApartmentRoomSuiteNumber = source.Address2;
            target.City = source.City;
            target.PostalCode = source.PostalCode;
            target.StateAbbreviationTypeId = (int) source.State.GetValueOrDefault();
        }
    }
}
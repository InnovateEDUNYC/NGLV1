using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class StudentHomeAddressMapper : MapperBase<CreateStudentModel, StudentAddress>
    {
        private const int HomeAddressTypeId = (int) AddressTypeEnum.Home;

        public override void Map(CreateStudentModel source, StudentAddress target)
        {
            target.AddressTypeId = HomeAddressTypeId;
            target.StreetNumberName = source.StreetNumberName;
            target.ApartmentRoomSuiteNumber = source.ApartmentRoomSuiteNumber;
            target.City = source.City;
            target.PostalCode = source.PostalCode;
            target.StateAbbreviationTypeId = (int) source.StateAbbreviationTypeEnum.GetValueOrDefault();
        }
    }
}
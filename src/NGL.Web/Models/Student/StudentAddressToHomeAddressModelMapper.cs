using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class StudentAddressToHomeAddressModelMapper : MapperBase<StudentAddress, HomeAddressModel>
    {
        public override void Map(StudentAddress source, HomeAddressModel target)
        {
            target.StudentUsi = source.StudentUSI;
            target.Address = source.StreetNumberName;
            target.Address2 = source.ApartmentRoomSuiteNumber;
            target.City = source.City;
            target.State = (StateAbbreviationTypeEnum) source.StateAbbreviationTypeId;
            target.PostalCode = source.PostalCode;
        }
    }
}
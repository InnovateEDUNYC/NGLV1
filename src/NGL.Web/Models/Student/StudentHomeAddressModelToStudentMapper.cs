namespace NGL.Web.Models.Student
{
    public class StudentHomeAddressModelToStudentMapper : MapperBase<HomeAddressModel, Data.Entities.StudentAddress>
    {
        public override void Map(HomeAddressModel source, Data.Entities.StudentAddress target)
        {
            target.StreetNumberName = source.Address;
            target.ApartmentRoomSuiteNumber = source.Address2;
            target.City = source.City;
            target.PostalCode = source.PostalCode;
            target.StateAbbreviationTypeId = (int) source.State.GetValueOrDefault();
        }
    }
}
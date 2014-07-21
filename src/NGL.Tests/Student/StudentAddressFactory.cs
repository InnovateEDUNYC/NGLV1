using NGL.Web.Data.Entities;

namespace NGL.Tests.Student
{
    public static class StudentAddressFactory
    {
        private const int AddressType = (int) AddressTypeEnum.Home;
        private const string StreetNumberName = "200 E Randolph";
        private const string ApartmentRoomSuiteNumber = "25th Floor";
        private const string City = "Chicago";
        private const int State = (int) StateAbbreviationTypeEnum.IL;
        private const string PostalCode = "60601";


        public static StudentAddress CreateStudentAddress()
        {
            return new StudentAddress
            {
                AddressTypeId = AddressType,
                StreetNumberName = StreetNumberName,
                ApartmentRoomSuiteNumber = ApartmentRoomSuiteNumber,
                City = City,
                StateAbbreviationTypeId = State,
                PostalCode = PostalCode
            };
        }

    }
}

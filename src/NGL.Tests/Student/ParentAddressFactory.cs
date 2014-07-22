using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Student
{
    public class ParentAddressFactory
    {
        private const int AddressType = (int) AddressTypeEnum.Home;
        private const string StreetNumberName = "GF-01 and MZ-01";
        private const string ApartmentRoomSuiteNumber = "Tower C";
        private const string City = "Pune";
        private const int State = (int) StateAbbreviationTypeEnum.IN;
        private const string PostalCode = "98142";
        public static ParentAddress CreateParentHomeAddress()
        {
            return new ParentAddress
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

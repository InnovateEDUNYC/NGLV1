using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class StudentHomeAddressBuilder
    {
        private const int HomeAddressTypeId = (int) AddressTypeEnum.Home;

        public StudentAddress Build(CreateStudentModel source)
        {
            return new StudentAddress
            {
                AddressTypeId = HomeAddressTypeId,
                StreetNumberName = source.StreetNumberName,
                ApartmentRoomSuiteNumber = source.ApartmentRoomSuiteNumber,
                City = source.City,
                PostalCode = source.PostalCode,
                StateAbbreviationTypeId = (int)source.StateAbbreviationTypeEnum.GetValueOrDefault()
            };
        }
    }
}
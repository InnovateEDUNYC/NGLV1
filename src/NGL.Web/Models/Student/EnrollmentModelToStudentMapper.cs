﻿using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class EnrollmentModelToStudentMapper : IMapper<EnrollmentModel, Data.Entities.Student>
    {
        public void Map(EnrollmentModel source, Data.Entities.Student target)
        {
            const int homeAddressTypeId = 1;
            target.StudentUSI = source.StudentUsi; 
            target.FirstName = source.FirstName;
            target.LastSurname = source.LastSurname;
            target.HispanicLatinoEthnicity = source.HispanicLatinoEthnicity;
            target.SexTypeId = source.SexTypeId;
            target.BirthDate = source.BirthDate;
            target.OldEthnicityTypeId = source.OldEthnicityTypeId;

            target.StudentAddresses.Add(new StudentAddress
            { 
                AddressTypeId = homeAddressTypeId, 
                StreetNumberName = source.StreetNumberName,
                ApartmentRoomSuiteNumber = source.ApartmentRoomSuiteNumber,
                City = source.City,
                PostalCode = source.PostalCode,
                StateAbbreviationTypeId = source.StateAbbreviationTypeId
            });

            var studentLanguage = new StudentLanguage
            {   

                LanguageDescriptorId = source.LanguageTypeId
            };

            studentLanguage.StudentLanguageUses.Add( new StudentLanguageUse
            {   
                LanguageDescriptorId = source.LanguageTypeId,
                LanguageUseTypeId = source.LanguageUseTypeId
            });

            target.StudentLanguages.Add(studentLanguage);
        }   
    }
}
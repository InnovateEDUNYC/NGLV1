using System;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.Student
{
    public class EnrollmentModelToStudentMapper : IMapper<EnrollmentModel, Data.Entities.Student>
    {
        private readonly ILanguageDescriptorRepository _repository;
        private const int HomeAddressTypeId = 1;
        private const int HomeLanguageTypeId = 1;

        public EnrollmentModelToStudentMapper(ILanguageDescriptorRepository repository)
        {
            _repository = repository;
        }

        public void Map(EnrollmentModel source, Data.Entities.Student target)
        {
            SetStudentNativeProperties(source, target);

            SetStudentAddress(source, target);

            SetStudentLanguage(source, target);
        }

        private static void SetStudentNativeProperties(EnrollmentModel source, Data.Entities.Student target)
        {
            if (source.StudentUsi != null) target.StudentUSI = (int)source.StudentUsi;
            target.FirstName = source.FirstName;
            target.LastSurname = source.LastSurname;
            target.HispanicLatinoEthnicity = source.HispanicLatinoEthnicity;
            target.SexTypeId = source.SexTypeId;
            if (source.BirthDate != null) target.BirthDate = (DateTime) source.BirthDate;
            target.OldEthnicityTypeId = source.OldEthnicityTypeId;
        }

        private void SetStudentLanguage(EnrollmentModel source, Data.Entities.Student target)
        {

            var languageDescriptor = _repository.GetLanguageDescriptor(source.LanguageTypeId.Value);

            var studentLanguage = new StudentLanguage
            {
                LanguageDescriptorId = languageDescriptor.LanguageDescriptorId
            };

            studentLanguage.StudentLanguageUses.Add(new StudentLanguageUse
            {
                LanguageDescriptorId = languageDescriptor.LanguageDescriptorId,
                LanguageUseTypeId = HomeLanguageTypeId
            });

            target.StudentLanguages.Add(studentLanguage);
        }

        private static void SetStudentAddress(EnrollmentModel source, Data.Entities.Student target)
        {
            
            target.StudentAddresses.Add(new StudentAddress
            {
                AddressTypeId = HomeAddressTypeId,
                StreetNumberName = source.StreetNumberName,
                ApartmentRoomSuiteNumber = source.ApartmentRoomSuiteNumber,
                City = source.City,
                PostalCode = source.PostalCode,
                StateAbbreviationTypeId = source.StateAbbreviationTypeId.Value
            });
        }
    }
}
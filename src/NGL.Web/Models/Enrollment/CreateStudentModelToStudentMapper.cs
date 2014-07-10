using System;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class CreateStudentModelToStudentMapper : IMapper<CreateStudentModel, Data.Entities.Student>
    {
        private readonly IMapper<ParentEnrollmentInfoModel, Parent> _parentMapper;
        private const int HomeAddressTypeId = (int)AddressTypeEnum.Home;
        private const int HomeLanguageTypeId = (int)LanguageUseTypeEnum.Homelanguage;

        public CreateStudentModelToStudentMapper(IMapper<ParentEnrollmentInfoModel, Parent> parentMapper)
        {
            _parentMapper = parentMapper;
        }

        public void Map(CreateStudentModel source, Data.Entities.Student target)
        {
            SetStudentNativeProperties(source, target);
            SetStudentAddress(source, target);
            SetStudentLanguage(source, target);

            var parent = new Parent();
            var studentParentAssociation = new StudentParentAssociation
            {
                Parent = parent,
                RelationTypeId = (int) source.ParentEnrollmentInfoModel.RelationshipToStudent
            };

            _parentMapper.Map(source.ParentEnrollmentInfoModel, parent);

            target.StudentParentAssociations.Add(studentParentAssociation);

        }

        private static void SetStudentNativeProperties(CreateStudentModel source, Data.Entities.Student target)
        {
            if (source.StudentUsi != null) target.StudentUSI = (int)source.StudentUsi;
            target.FirstName = source.FirstName;
            target.LastSurname = source.LastName;
            target.HispanicLatinoEthnicity = source.HispanicLatinoEthnicity;
            target.SexTypeId = (int) source.SexTypeEnum.GetValueOrDefault();
            if (source.BirthDate != null) target.BirthDate = (DateTime) source.BirthDate;
            target.OldEthnicityTypeId = (int?) source.OldEthnicityTypeEnum.GetValueOrDefault();
        }

        private void SetStudentLanguage(CreateStudentModel source, Data.Entities.Student target)
        {

            var languageDescriptor = source.LanguageDescriptorEnum.GetValueOrDefault();

            var studentLanguage = new StudentLanguage
            {
                LanguageDescriptorId = (int) languageDescriptor
            };

            studentLanguage.StudentLanguageUses.Add(new StudentLanguageUse
            {
                LanguageDescriptorId = (int) languageDescriptor,
                LanguageUseTypeId = HomeLanguageTypeId
            });

            target.StudentLanguages.Add(studentLanguage);
        }

        private static void SetStudentAddress(CreateStudentModel source, Data.Entities.Student target)
        {
            
            target.StudentAddresses.Add(new StudentAddress
            {
                AddressTypeId = HomeAddressTypeId,
                StreetNumberName = source.StreetNumberName,
                ApartmentRoomSuiteNumber = source.ApartmentRoomSuiteNumber,
                City = source.City,
                PostalCode = source.PostalCode,
                StateAbbreviationTypeId = (int) source.StateAbbreviationTypeEnum.GetValueOrDefault()
            });
        }
    }
}
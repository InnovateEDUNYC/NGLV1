using System;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class CreateStudentModelToStudentMapper : IMapper<CreateStudentModel, Data.Entities.Student>
    {
        private readonly IBuilder<CreateStudentModel, StudentAddress> _studentAddressBuilder;
        private readonly IBuilder<CreateStudentModel, StudentLanguage> _studentLanguageBuilder;
        private readonly IBuilder<ParentEnrollmentInfoModel, StudentParentAssociation> _studentParentAssociationBuilder;

        public CreateStudentModelToStudentMapper(IBuilder<CreateStudentModel, StudentAddress> studentAddressBuilder, IBuilder<CreateStudentModel, StudentLanguage> studentLanguageBuilder, IBuilder<ParentEnrollmentInfoModel, StudentParentAssociation> studentParentAssociationBuilder)
        {
            _studentAddressBuilder = studentAddressBuilder;
            _studentLanguageBuilder = studentLanguageBuilder;
            _studentParentAssociationBuilder = studentParentAssociationBuilder;
        }

        public void Map(CreateStudentModel source, Data.Entities.Student target)
        {
            SetStudentNativeProperties(source, target);

            var studentAddress = _studentAddressBuilder.Build(source);
            target.StudentAddresses.Add(studentAddress);

            var studentLanguage = _studentLanguageBuilder.Build(source);
            target.StudentLanguages.Add(studentLanguage);

            var studentParentAssociation = _studentParentAssociationBuilder.Build(source.ParentEnrollmentInfoModel);
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



    }
}
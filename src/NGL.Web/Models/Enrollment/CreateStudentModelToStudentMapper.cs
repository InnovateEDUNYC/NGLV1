using System;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class CreateStudentModelToStudentMapper : IMapper<CreateStudentModel, Data.Entities.Student>
    {
        private readonly IMapper<ParentEnrollmentInfoModel, Parent> _parentMapper;
        private readonly IMapper<ParentEnrollmentInfoModel, StudentParentAssociation> _studentParentAssociationMapper;

        public CreateStudentModelToStudentMapper(IMapper<ParentEnrollmentInfoModel, Parent> parentMapper, IMapper<ParentEnrollmentInfoModel, StudentParentAssociation> studentParentAssociationMapper)
        {
            _parentMapper = parentMapper;
            _studentParentAssociationMapper = studentParentAssociationMapper;
        }

        public void Map(CreateStudentModel source, Data.Entities.Student target)
        {
            SetStudentNativeProperties(source, target);

            var studentAddress = new StudentHomeAddressBuilder().Build(source);
            target.StudentAddresses.Add(studentAddress);

            var studentLanguage = new StudentHomeLanguageBuilder().Build(source);
            target.StudentLanguages.Add(studentLanguage);

            var studentParentAssociationBuilder = new StudentParentAssociationBuilder(_studentParentAssociationMapper, _parentMapper);
            var studentParentAssociation = studentParentAssociationBuilder.Build(source.ParentEnrollmentInfoModel);

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
using System;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class CreateStudentModelToStudentMapper : MapperBase<CreateStudentModel, Data.Entities.Student>
    {
        private readonly IMapper<CreateStudentModel, StudentAddress> _studentAddressMapper;
        private readonly IMapper<CreateStudentModel, StudentLanguage> _studentLanguageMapper;
        private readonly IMapper<ParentEnrollmentInfoModel, StudentParentAssociation> _studentParentAssociationMapper;

        public CreateStudentModelToStudentMapper(
            IMapper<CreateStudentModel, StudentAddress> studentAddressMapper, 
            IMapper<CreateStudentModel, StudentLanguage> studentLanguageMapper, 
            IMapper<ParentEnrollmentInfoModel, StudentParentAssociation> studentParentAssociationMapper)
        {
            _studentAddressMapper = studentAddressMapper;
            _studentLanguageMapper = studentLanguageMapper;
            _studentParentAssociationMapper = studentParentAssociationMapper;
        }

        public override void Map(CreateStudentModel source, Data.Entities.Student target)
        {
            SetStudentNativeProperties(source, target);

            var studentAddress = _studentAddressMapper.Build(source);
            target.StudentAddresses.Add(studentAddress);

            var studentLanguage = _studentLanguageMapper.Build(source);
            target.StudentLanguages.Add(studentLanguage);

            var studentParentAssociation = _studentParentAssociationMapper.Build(source.ParentEnrollmentInfoModel);
            target.StudentParentAssociations.Add(studentParentAssociation);

        }

        private static void SetStudentNativeProperties(CreateStudentModel source, Data.Entities.Student target)
        {
            if (source.StudentUsi != null) target.StudentUSI = (int)source.StudentUsi;
            target.FirstName = source.FirstName;
            target.LastSurname = source.LastName;
            target.HispanicLatinoEthnicity = source.HispanicLatinoEthnicity;
            target.SexTypeId = (int) source.Sex.GetValueOrDefault();
            target.BirthDate = source.BirthDate.GetValueOrDefault();
            target.StudentRaces.Add(new StudentRace {RaceTypeId = (int)source.Race.GetValueOrDefault()});
        }
    }
}

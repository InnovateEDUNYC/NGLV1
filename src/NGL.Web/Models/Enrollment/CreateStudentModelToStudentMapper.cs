using System.Collections.Generic;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class CreateStudentModelToStudentMapper : MapperBase<CreateStudentModel, Data.Entities.Student>
    {
        private readonly IMapper<CreateStudentModel, StudentAddress> _studentAddressMapper;
        private readonly IMapper<CreateParentModel, StudentParentAssociation> _studentParentAssociationMapper;
        private readonly IMapper<StudentBiographicalInformationModel, Data.Entities.Student> _studentBiographicalInfoMapper;


        public CreateStudentModelToStudentMapper(
            IMapper<CreateStudentModel, StudentAddress> studentAddressMapper, 
            CreateParentModelToStudentParentAssociationMapper studentParentAssociationMapper, 
            IMapper<StudentBiographicalInformationModel, Data.Entities.Student> studentBiographicalInfoMapper)
        {
            _studentAddressMapper = studentAddressMapper;
            _studentParentAssociationMapper = studentParentAssociationMapper;
            _studentBiographicalInfoMapper = studentBiographicalInfoMapper;
        }

        public override void Map(CreateStudentModel source, Data.Entities.Student target)
        {
            SetStudentNativeProperties(source, target);

            var studentAddress = _studentAddressMapper.Build(source);
            target.StudentAddresses.Add(studentAddress);

            var firstParentAssociation = _studentParentAssociationMapper.Build(source.FirstParent);
            target.StudentParentAssociations.Add(firstParentAssociation);
            
            if (source.AddSecondParent)
            {
                var secondParentAssociation = _studentParentAssociationMapper.Build(source.SecondParent);
                target.StudentParentAssociations.Add(secondParentAssociation);
            }
        }

        private void SetStudentNativeProperties(CreateStudentModel source, Data.Entities.Student target)
        {
            if (source.StudentUsi != null) target.StudentUSI = (int)source.StudentUsi;
            target.FirstName = source.FirstName;
            target.LastSurname = source.LastName;

            _studentBiographicalInfoMapper.Map(source.BiographicalInformation, target);
        }
    }
}

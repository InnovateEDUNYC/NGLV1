using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class ParentEnrollmentInfoModelToStudentParentAssociationMapper : MapperBase<ParentEnrollmentInfoModel, StudentParentAssociation>
    {
        private readonly IMapper<ParentEnrollmentInfoModel, Parent> _parentMapper;

        public ParentEnrollmentInfoModelToStudentParentAssociationMapper(IMapper<ParentEnrollmentInfoModel, Parent> parentMapper)
        {
            _parentMapper = parentMapper;
        }

        public override void Map(ParentEnrollmentInfoModel source, StudentParentAssociation target)
        {
            target.RelationTypeId = (int)source.RelationshipToStudent.GetValueOrDefault();
            target.PrimaryContactStatus = source.MakeThisPrimaryContact;
            target.LivesWith = source.SameAddressAsStudent;
            target.Parent = _parentMapper.Build(source);
        }
    }
}
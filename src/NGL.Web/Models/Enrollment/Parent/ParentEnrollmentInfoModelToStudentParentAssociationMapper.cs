using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment.Parent
{
    public class ParentEnrollmentInfoModelToStudentParentAssociationMapper :
        MapperBase<ParentEnrollmentInfoModel, StudentParentAssociation>
    {
        private readonly IMapper<ParentEnrollmentInfoModel, Data.Entities.Parent> _parentMapper;
        private readonly IMapper<ParentEnrollmentInfoModel, ParentAddress> _parentAddressMapper;

        public ParentEnrollmentInfoModelToStudentParentAssociationMapper(
            IMapper<ParentEnrollmentInfoModel, Data.Entities.Parent> parentMapper, IMapper<ParentEnrollmentInfoModel, ParentAddress> parentAddressMapper)
        {
            _parentMapper = parentMapper;
            _parentAddressMapper = parentAddressMapper;
        }

        public override void Map(ParentEnrollmentInfoModel source, StudentParentAssociation target)
        {
            target.RelationTypeId = (int)source.RelationshipToStudent.GetValueOrDefault();
            target.PrimaryContactStatus = source.MakeThisPrimaryContact;
            target.LivesWith = source.SameAddressAsStudent;
            target.Parent = _parentMapper.Build(source);
            if (ParentHasDifferentAddressThanStudent(source))
            {
                target.Parent.ParentAddresses.Add(_parentAddressMapper.Build(source));
            }
        }

        private bool ParentHasDifferentAddressThanStudent(ParentEnrollmentInfoModel source)
        {
            return !source.SameAddressAsStudent;
        }
    }
}
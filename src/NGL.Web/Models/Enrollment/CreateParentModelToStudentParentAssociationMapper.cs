using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class CreateParentModelToStudentParentAssociationMapper :
        MapperBase<CreateParentModel, StudentParentAssociation>
    {
        private readonly IMapper<CreateParentModel, Parent> _parentMapper;
        private readonly IMapper<CreateParentModel, ParentAddress> _parentAddressMapper;

        public CreateParentModelToStudentParentAssociationMapper(
            IMapper<CreateParentModel, Parent> parentMapper, IMapper<CreateParentModel, ParentAddress> parentAddressMapper)
        {
            _parentMapper = parentMapper;
            _parentAddressMapper = parentAddressMapper;
        }

        public override void Map(CreateParentModel source, StudentParentAssociation target)
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

        private bool ParentHasDifferentAddressThanStudent(CreateParentModel source)
        {
            return !source.SameAddressAsStudent;
        }
    }
}
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class StudentParentAssociationBuilder
    {
        private readonly IMapper<ParentEnrollmentInfoModel, Parent> _parentMapper;
        private readonly IMapper<ParentEnrollmentInfoModel, StudentParentAssociation> _studentParentAssociationMapper;

        public StudentParentAssociationBuilder(IMapper<ParentEnrollmentInfoModel,StudentParentAssociation> studentParentAssociationMapper, IMapper<ParentEnrollmentInfoModel, Parent> parentMapper)
        {
            _studentParentAssociationMapper = studentParentAssociationMapper;
            _parentMapper = parentMapper;
        }

        public StudentParentAssociation Build(ParentEnrollmentInfoModel source)
        {
            var parent = new Parent();
            var studentParentAssociation = new StudentParentAssociation();

            _studentParentAssociationMapper.Map(source, studentParentAssociation);
            _parentMapper.Map(source, parent);

            studentParentAssociation.Parent = parent;
            return studentParentAssociation;
        }
    }
}
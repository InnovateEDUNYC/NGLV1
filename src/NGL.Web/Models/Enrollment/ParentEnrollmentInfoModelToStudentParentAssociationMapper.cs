using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class ParentEnrollmentInfoModelToStudentParentAssociationMapper : IMapper<ParentEnrollmentInfoModel, StudentParentAssociation>
    {
        public void Map(ParentEnrollmentInfoModel source, StudentParentAssociation target)
        {
            target.RelationTypeId = (int)source.RelationshipToStudent.GetValueOrDefault();
            target.PrimaryContactStatus = source.IsPrimaryContact;
            target.LivesWith = source.SameAddressAsStudent;
        }

    }
}
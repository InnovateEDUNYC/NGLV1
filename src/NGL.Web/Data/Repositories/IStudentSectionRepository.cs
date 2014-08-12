using NGL.Web.Data.Entities;

namespace NGL.Web.Data.Repositories
{
    public interface IStudentSectionRepository
    {
        void Delete(StudentSectionAssociation studentSectionAssociation);
        StudentSectionAssociation GetByIdentity(int studentSectionIdentity);
    }
}

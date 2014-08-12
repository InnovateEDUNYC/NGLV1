using NGL.Web.Data.Entities;

namespace NGL.Web.Data.Repositories
{
    public interface IStudentSectionRepository
    {
        void DeleteByIdentity(int studentSectionIdentity);
        StudentSectionAssociation GetByIdentity(int studentSectionIdentity);
    }
}

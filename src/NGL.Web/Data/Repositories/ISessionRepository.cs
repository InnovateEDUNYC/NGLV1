using NGL.Web.Data.Entities;

namespace NGL.Web.Data.Repositories
{
    public interface ISessionRepository
    {
        Session GetWithSectionsById(int sessionIdentity);
        Session GetById(int sessionIdentity);
        int GetDependencyCount(int sessionIdentity);
        void Remove(int sessionIdentity);
    }
}

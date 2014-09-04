using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Repositories
{
    public interface ILocationRepository : IRepositoryBase
    {
        int GetDependencyCount(int locationIdentity);
        void Remove(int locationIdentity);
    }
}
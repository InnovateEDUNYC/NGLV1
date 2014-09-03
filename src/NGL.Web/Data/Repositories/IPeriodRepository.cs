using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Repositories
{
    public interface IPeriodRepository : IRepositoryBase
    {
        void Remove(string classPeriodName);
        int GetDependencyCount(string classPeriodName);
    }
}
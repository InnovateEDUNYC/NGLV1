using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Repositories
{
    public class LookupRepository : GenericRepository, ILookupRepository
    {
        public LookupRepository(INglDbContext dbContext) : base(dbContext)
        {

        }
    }
}
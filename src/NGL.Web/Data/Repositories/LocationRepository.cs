using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Exceptions;

namespace NGL.Web.Data.Repositories
{
    public class LocationRepository : RepositoryBase, ILocationRepository
    {
        public LocationRepository(INglDbContext dbContext) : base(dbContext)
        {
        }

        public int GetDependencyCount(int locationIdentity)
        {
            var dependencies = 0;
            dependencies += DbContext.Set<Section>().Count(s => s.Location.LocationIdentity == locationIdentity);

            return dependencies;
        }

        public void Remove(int locationIdentity)
        {
            var existing = DbContext.Set<Location>().First(l => l.LocationIdentity == locationIdentity);
            try
            {
                DbContext.Set<Location>().Remove(existing);
                Save();
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException == null || e.InnerException.InnerException == null) throw;
                var innerException = e.InnerException.InnerException as SqlException;
                if (innerException != null && innerException.Number == ConstraintExceptionNumber)
                {
                    throw new NglException();
                }
                throw;
            }
        }
    }
}
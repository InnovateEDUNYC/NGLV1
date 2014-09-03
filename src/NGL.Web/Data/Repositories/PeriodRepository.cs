using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Exceptions;

namespace NGL.Web.Data.Repositories
{
    public class PeriodRepository : RepositoryBase, IPeriodRepository
    {
        public PeriodRepository(INglDbContext dbContext) : base(dbContext)
        {
        }

        public void Remove(string classPeriodName)
        {
            var existing = DbContext.Set<ClassPeriod>().First(cp => cp.ClassPeriodName == classPeriodName);
            try
            {
                DbContext.Set<ClassPeriod>().Remove(existing);
                Save();
            }      
            catch (DbUpdateException e)
            {
                if (e.InnerException == null || e.InnerException.InnerException == null) throw;
                var innerException = e.InnerException.InnerException as SqlException;
                if (innerException != null && innerException.Number == 547)
                {
                    throw new NglException();
                }
                throw;
            }
        }

        public int GetDependencyCount(string classPeriodName)
        {
            var dependencies = 0;
            dependencies += DbContext.Set<Section>().Count(s => s.ClassPeriodName == classPeriodName);
            dependencies += DbContext.Set<BellScheduleMeetingTime>().Count(s => s.ClassPeriodName == classPeriodName);
            dependencies += DbContext.Set<InterventionMeetingTime>().Count(s => s.ClassPeriodName == classPeriodName);
            return dependencies;
        }
    }
}
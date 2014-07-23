using System.Data.Entity;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Repositories
{
    public class SchoolRepository : RepositoryBase, ISchoolRepository
    {
        public SchoolRepository(INglDbContext dbContext) : base(dbContext)
        {
        }

        public School GetSchool()
        {
            // we should have one school only; so get the first one
            return DbContext.Set<School>().Include(s => s.EducationOrganization).FirstOrDefault();
        }
    }
}
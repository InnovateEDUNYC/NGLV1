using System.Data.Entity;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Repositories
{
    public class SessionRepository : RepositoryBase, ISessionRepository
    {
        public SessionRepository(INglDbContext dbContext) : base(dbContext) { }

        public Session GetWithSectionsById(int sessionIdentity)
        {
            return DbContext.Set<Session>()
                .Where(s => s.SessionIdentity == sessionIdentity)
                .Include(s => s.Sections)
                .ToList().SingleOrDefault();
        }

        public Session GetById(int sessionIdentity)
        {
            return DbContext.Set<Session>().SingleOrDefault(s => s.SessionIdentity == sessionIdentity);
        }
    }
}
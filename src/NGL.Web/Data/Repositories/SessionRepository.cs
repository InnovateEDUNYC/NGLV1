using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Exceptions;

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

        public int GetDependencyCount(int sessionIdentity)
        {
            var dependencies = 0;
            dependencies += DbContext.Set<CourseOffering>().Count(co => co.Session.SessionIdentity == sessionIdentity);
            dependencies += DbContext.Set<ParentCourseGrade>().Count(pcg => pcg.Session.SessionIdentity == sessionIdentity);
            dependencies += DbContext.Set<SessionAcademicWeek>().Count(saw => saw.Session.SessionIdentity == sessionIdentity);
            dependencies += DbContext.Set<SessionGradingPeriod>().Count(sgp => sgp.Session.SessionIdentity == sessionIdentity);
            dependencies += DbContext.Set<StudentSchoolAttendanceEvent>().Count(ssae => ssae.Session.SessionIdentity == sessionIdentity);
            return dependencies;
        }

        public void Remove(int sessionIdentity)
        {
            var existing = DbContext.Set<Session>().First(s => s.SessionIdentity == sessionIdentity);
            try
            {
                DbContext.Set<Session>().Remove(existing);
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
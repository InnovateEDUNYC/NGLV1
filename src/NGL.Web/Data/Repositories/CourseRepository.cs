using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Exceptions;

namespace NGL.Web.Data.Repositories
{
    public class CourseRepository : RepositoryBase, ICourseRepository
    {
        public CourseRepository(INglDbContext dbContext) : base(dbContext)
        {
        }

        public void Delete(int id)
        {
            var courseToDelete = DbContext.Set<Course>()
                .Where(c => c.CourseIdentity == id)
                .Include(c => c.CourseOfferings).FirstOrDefault();
            try
            {
                var courseOfferingsCount = courseToDelete.CourseOfferings.Count;
                for (var i = 0; i < courseOfferingsCount; i++)
                {
                    var child = courseToDelete.CourseOfferings.FirstOrDefault();
                    DbContext.Set<CourseOffering>().Remove(child);
                }

                DbContext.Set<Course>().Remove(courseToDelete);
                Save();
            }
            catch (DbUpdateException e)
            {
                var inner = e.InnerException;
                var innerInner = inner.InnerException as SqlException;
                if (innerInner != null && innerInner.Number == 547)
                {
                    throw new NglException();
                }
                throw;
            }
        }

        public bool HasDependencies(int id)
        {
            var course = GetWithCourseOfferings(id);

            return course != null && course.CourseOfferings.Any(co => co.Sections.Any());
        }

        private Course GetWithCourseOfferings(int id)
        {
            return DbContext.Set<Course>()
                    .Where(c => c.CourseIdentity == id)
                    .Include(c => c.CourseOfferings)
                    .Include(c => c.CourseOfferings.Select(co => co.Sections))
                    .FirstOrDefault();
        }

        private Course GetById(int id)
        {
            return DbContext.Set<Course>()
                .First(pc => pc.CourseIdentity == id);
        }
    }
}
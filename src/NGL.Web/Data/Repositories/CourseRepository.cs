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
            var courseToDelete = GetById(id);

            DbContext.Set<Course>().Remove(courseToDelete);

            try
            {
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

        private Course GetById(int id)
        {
            return DbContext.Set<Course>()
                .First(pc => pc.CourseIdentity == id);
        }
    }
}
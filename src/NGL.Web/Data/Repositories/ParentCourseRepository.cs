using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Repositories
{
    public class ParentCourseRepository : RepositoryBase, IParentCourseRepository
    {
        public ParentCourseRepository(INglDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<ParentCourse> GetParentCourses()
        {
            return DbContext.Set<ParentCourse>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;

namespace NGL.Web.Data.Repositories
{
    public interface IParentCourseRepository
    {
        IEnumerable<ParentCourse> GetParentCourses();
    }
}
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Queries
{
    public class CourseByCourseCodeQuery : IQuery<Course>
    {
        private string _courseCode;

        public CourseByCourseCodeQuery(string courseCode)
        {
            _courseCode = courseCode;
        }

        public IQueryable<Course> ApplyPredicate(IQueryable<Course> inputSet)
        {
            return inputSet.Where(c => c.CourseCode == _courseCode);
        }
    }
}
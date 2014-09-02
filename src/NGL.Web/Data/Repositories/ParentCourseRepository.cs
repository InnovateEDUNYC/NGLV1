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

        public ParentCourse GetParentCourse(string courseCode)
        {
            return DbContext.Set<ParentCourse>().FirstOrDefault(pc => pc.Courses.Any(c => c.CourseCode == courseCode));
        }

        public List<ParentCourseGrade> GetParentCourseGrades(string courseCode)
        {
            return DbContext.Set<ParentCourseGrade>()
                .Where(g => g.ParentCourse.Courses.Any(c => c.CourseCode == courseCode))
                .Include(g => g.Student).ToList();
        }

        public ParentCourseGrade GetParentCourseGrade(int StudentUSI, Guid parentCourseId)
        {
            return DbContext.Set<ParentCourseGrade>().FirstOrDefault(pcg => pcg.StudentUSI == StudentUSI && pcg.ParentCourseId == parentCourseId);
        }

        public List<Student> GetStudents(int sessionId, Guid parentCourseId)
        {
            var students = DbContext.Set<Course>()
                .Where(c => c.ParentCourseId == parentCourseId)
                .SelectMany(c => c.CourseOfferings.Where(co => co.Session.SessionIdentity == sessionId))
                .SelectMany(co => co.Sections)
                .SelectMany(s => s.StudentSectionAssociations)
                .Select(ssa => ssa.Student).Distinct();

            return students.ToList();
        }

        public ParentCourse GetById(Guid parentCourseId)
        {
            return DbContext.Set<ParentCourse>()
                .First(pc => pc.Id == parentCourseId);
        }

        public List<ParentCourseGrade> GetParentCourseGrades(Guid parentCourseId, int sessionId)
        {
            return DbContext.Set<ParentCourseGrade>()
                .Where(pcg => pcg.ParentCourseId == parentCourseId && pcg.Session.SessionIdentity == sessionId)
                .Include(pcg => pcg.Student)
                .Include(pcg => pcg.ParentCourse)
                .Include(pcg => pcg.Session)
                .ToList();
        }

        public void Delete(ParentCourse parentCourse)
        {
            DbContext.Set<ParentCourse>().Remove(parentCourse);
        }
    }
}
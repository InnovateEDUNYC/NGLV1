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

        ParentCourse GetParentCourse(string courseCode);

        List<ParentCourseGrade> GetParentCourseGrades(string courseCode);

        ParentCourseGrade GetParentCourseGrade(int StudentUSI, Guid parentCourseId);
        List<Student> GetStudents(int sessionId, Guid parentCourseId);
        ParentCourse GetById(Guid parentCourseId);
        List<ParentCourseGrade> GetParentCourseGrades(Guid parentCourseId, int sessionId);
    }
}
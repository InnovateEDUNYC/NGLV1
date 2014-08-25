using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class ParentCourseGradeBuilder
    {
        private int _schoolId = 1;
        private short _schoolYear = 2014;
        private int _termTypeId = 2;
        private int _studentUsi = 123;
        private string _gradeEarned = "A";
        private Web.Data.Entities.Student _student;
        private Web.Data.Entities.Session _session;
        private Web.Data.Entities.ParentCourse _parentCourse;

        public ParentCourseGrade Build()
        {
            return new ParentCourseGrade
            {
                SchoolId = _schoolId,
                SchoolYear = _schoolYear,
                TermTypeId = _termTypeId,
                StudentUSI = _studentUsi,
                GradeEarned = _gradeEarned,
                Student = _student,
                Session = _session,
                ParentCourse = _parentCourse
            };
        }

        public ParentCourseGradeBuilder WithStudent(Web.Data.Entities.Student student)
        {
            _student = student;
            _studentUsi = student.StudentUSI;
            return this;
        }

        public ParentCourseGradeBuilder WithSession(Web.Data.Entities.Session session)
        {
            _session = session;
            _parentCourse = parentCourse;
            return this;
        }

        public ParentCourseGradeBuilder WithParentCourse(Web.Data.Entities.ParentCourse parentCourse)
        {
            _parentCourse = parentCourse;
            return this;
        }
    }
}

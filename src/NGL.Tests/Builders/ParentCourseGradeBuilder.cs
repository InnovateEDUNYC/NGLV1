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
        private int _schoolId;
        private short _schoolYear;
        private int _termTypeId;
        private int _studentUsi;
        private string _gradeEarned;
        private Web.Data.Entities.Student _student;
        private Web.Data.Entities.Session _session;
        private Web.Data.Entities.ParentCourse _parentCourse;

        public ParentCourseGrade Build()
        {
            _schoolId = 1;
            _schoolYear = 2014;
            _termTypeId = 2;
            _studentUsi = 123;
            _gradeEarned = "A";
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
            return this;
        }

        public ParentCourseGradeBuilder WithParentCourse(Web.Data.Entities.ParentCourse parentCourse)
        {
            _parentCourse = parentCourse;
            return this;
        }
    }
}

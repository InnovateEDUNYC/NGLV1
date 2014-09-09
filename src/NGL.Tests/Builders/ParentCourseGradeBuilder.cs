using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class ParentCourseGradeBuilder
    {
        private const int SchoolId = 1;
        private const short SchoolYear = 2014;
        private const int TermTypeId = 2;
        private int _studentUsi = 123;
        private const string GradeEarned = "A";
        private Web.Data.Entities.Student _student;
        private Web.Data.Entities.Session _session;
        private Web.Data.Entities.ParentCourse _parentCourse;

        public ParentCourseGrade Build()
        {
            return new ParentCourseGrade
            {
                SchoolId = SchoolId,
                SchoolYear = SchoolYear,
                TermTypeId = TermTypeId,
                StudentUSI = _studentUsi,
                GradeEarned = GradeEarned,
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

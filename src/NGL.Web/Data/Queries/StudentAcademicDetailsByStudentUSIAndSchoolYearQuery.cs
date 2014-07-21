using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Queries
{
    public class StudentAcademicDetailsByStudentUsiAndSchoolYearQuery : IQuery<StudentAcademicDetail>
    {
        private readonly int _studentUsi;
        private readonly short _schoolYear;

        public StudentAcademicDetailsByStudentUsiAndSchoolYearQuery(int studentUsi, short schoolYear)
        {
            _studentUsi = studentUsi;
            _schoolYear = schoolYear;
        }

        public IQueryable<StudentAcademicDetail> ApplyPredicate(IQueryable<StudentAcademicDetail> inputSet)
        {
            return inputSet.Where(sad => sad.StudentUSI == _studentUsi
                                         && sad.SchoolYear == _schoolYear);
        }
    }
}
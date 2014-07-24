using NGL.Web.Data.Entities;

namespace NGL.Tests.Student
{
    public class StudentAcademicDetailFactory
    {
        public static StudentAcademicDetail CreateStudentAcademicDetail()
        {
            return new StudentAcademicDetail
            {
                ReadingScore = 98,
                WritingScore = 78,
                MathScore = 80,
                GradeLevelTypeId = (int) GradeLevelTypeEnum._5thGrade,
                SchoolYear = (int) SchoolYearTypeEnum.Year2014,
                PerformanceHistoryFile = "/here/example",
                PerfomanceHistory = "An Incredible Student. Many Times I wasn't sure if I was the teacher or pupil. Pure Genius."
            };
        }
    }
}

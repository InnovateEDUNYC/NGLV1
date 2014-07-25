using NGL.Web.Data.Entities;

namespace NGL.Tests.Student
{
    public class StudentAcademicDetailBuilder
    {
        private const decimal ReadingScore = 98m;
        private const decimal WritingScore = 78m;
        private const decimal MathScore = 80m;
        private const int GradeLevelTypeId = (int) GradeLevelTypeEnum._5thGrade;
        private const int SchoolYear = (int) SchoolYearTypeEnum.Year2014;
        private const string PerformanceHistoryFileUrl = "/here/example";
        private const string AnIncredibleStudentManyTimesIWasnTSureIfIWasTheTeacherOrPupilPureGenius = "An Incredible Student. Many Times I wasn't sure if I was the teacher or pupil. Pure Genius.";


        public StudentAcademicDetail Build()
        {
            return new StudentAcademicDetail
            {
                ReadingScore = ReadingScore,
                WritingScore = WritingScore,
                MathScore = MathScore,
                GradeLevelTypeId = GradeLevelTypeId,
                SchoolYear = SchoolYear,
                PerformanceHistoryFile = PerformanceHistoryFileUrl,
                PerfomanceHistory = AnIncredibleStudentManyTimesIWasnTSureIfIWasTheTeacherOrPupilPureGenius
            };
        }



    }
}

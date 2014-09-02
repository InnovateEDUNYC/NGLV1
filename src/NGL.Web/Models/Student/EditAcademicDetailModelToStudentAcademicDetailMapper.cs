using NGL.Web.Data.Entities;
using NGL.Web.Models.Enrollment;

namespace NGL.Web.Models.Student
{
    public class EditAcademicDetailModelToStudentAcademicDetailMapper
    {
        public void Map(EditAcademicDetailModel source, StudentAcademicDetail target, string performanceHistoryFilePath)
        {
            target.ReadingScore = source.ReadingScore;
            target.WritingScore = source.WritingScore;
            target.MathScore = source.MathScore;
            target.PerfomanceHistory = source.PerformanceHistory;
            if (performanceHistoryFilePath != null) target.PerformanceHistoryFile = performanceHistoryFilePath;
        }
    }
}
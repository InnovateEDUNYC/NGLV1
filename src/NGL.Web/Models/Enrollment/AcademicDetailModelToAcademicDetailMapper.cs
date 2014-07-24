using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class AcademicDetailModelToAcademicDetailMapper : MapperBase<AcademicDetailModel, StudentAcademicDetail>
    {
        public override void Map(AcademicDetailModel source, StudentAcademicDetail target)
        {
            target.ReadingScore = source.Reading.GetValueOrDefault();
            target.WritingScore = source.Writing.GetValueOrDefault();
            target.MathScore = source.Math.GetValueOrDefault();
            target.SchoolYear = (short)source.SchoolYear;
            target.GradeLevelTypeId = (int) source.AnticipatedGrade;
            target.PerfomanceHistory = source.PerformanceHistory;
        }
    }
}
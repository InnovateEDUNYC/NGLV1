using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class AcademicDetailModelToAcademicDetailMapper : MapperBase<AcademicDetailModel, StudentAcademicDetail>
    {
        public override void Map(AcademicDetailModel source, StudentAcademicDetail target)
        {
            target.ReadingScore = source.Reading;
            target.WritingScore = source.Writing;
            target.MathScore = source.Math;
            target.SchoolYear = (short)source.SchoolYear;
            target.GradeLevelTypeId = (int) source.AnticipatedGrade.GetValueOrDefault();
            target.PerfomanceHistory = source.PerformanceHistory;
        }
    }
}
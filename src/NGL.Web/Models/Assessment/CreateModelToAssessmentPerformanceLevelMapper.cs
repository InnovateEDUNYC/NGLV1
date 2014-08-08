using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Assessment
{
    public class CreateModelToAssessmentPerformanceLevelMapper : MapperBase<CreateModel, AssessmentPerformanceLevel>
    {
        public override void Map(CreateModel source, AssessmentPerformanceLevel target)
        {
            target.AssessmentTitle = source.AssessmentTitle;
            target.AssessedGradeLevelDescriptorId = (int) source.GradeLevel.GetValueOrDefault();
            target.AssessmentReportingMethodTypeId = (int) source.ReportingMethod;
        }
    }
}
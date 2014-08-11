using Castle.DynamicProxy.Generators;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Models.Assessment
{
    public class CreateModelToAssessmentPerformanceLevelMapper : MapperBase<CreateModel, AssessmentPerformanceLevel>
    {
        private readonly IGenericRepository _genericRepository;

        public CreateModelToAssessmentPerformanceLevelMapper(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public override void Map(CreateModel source, AssessmentPerformanceLevel target)
        {
            target.AssessmentTitle = source.AssessmentTitle;
            target.AssessedGradeLevelDescriptorId = GetGradeLevelDescriptorFromType(source);
            target.AssessmentReportingMethodTypeId = (int) source.ReportingMethod;
        }

        private int GetGradeLevelDescriptorFromType(CreateModel source)
        {
            var gradeLevelDescriptor =
                _genericRepository.Get<GradeLevelDescriptor>(m => m.GradeLevelTypeId == (int)source.GradeLevel);
            return gradeLevelDescriptor.GradeLevelDescriptorId;
        }
    }
}
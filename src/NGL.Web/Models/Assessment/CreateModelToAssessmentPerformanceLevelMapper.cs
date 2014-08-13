using System;
using System.Collections.ObjectModel;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Expressions;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;

namespace NGL.Web.Models.Assessment
{
    public class CreateModelToAssessmentPerformanceLevelMapper : IPerformanceLevelMapper
    {
        private readonly IGenericRepository _genericRepository;

        public CreateModelToAssessmentPerformanceLevelMapper(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public void Map(CreateModel source, AssessmentPerformanceLevel target)
        {
            target.AssessmentTitle = source.AssessmentTitle;
            target.AssessmentReportingMethodTypeId = (int) source.ReportingMethod;
            MapGradeLevelTypeFromDescriptor(source, target);
        }

        public AssessmentPerformanceLevel BuildWithPerformanceLevel(CreateModel createModel,
            Data.Entities.Assessment assessment,
            PerformanceLevelDescriptorEnum performanceLevelDescriptor)
        {
            var expression = new PerformanceLevelMapperExpression(assessment, performanceLevelDescriptor);
            var assessmentPerformanceLevel = Build(createModel, expression.Expression);

            MapMinimumScore(createModel, performanceLevelDescriptor, assessmentPerformanceLevel);
            AddAssessmentPerformanceLevel(assessment, assessmentPerformanceLevel);

            return assessmentPerformanceLevel;
        }

        public AssessmentPerformanceLevel Build(CreateModel source, Action<AssessmentPerformanceLevel> injectProperties)
        {
            var target = Build(source);
            injectProperties(target);
            return target;
        }

        public AssessmentPerformanceLevel Build(CreateModel source)
        {
            var target = new AssessmentPerformanceLevel();
            Map(source, target);
            return target;
        }

        private void MapGradeLevelTypeFromDescriptor(CreateModel source, AssessmentPerformanceLevel target)
        {
            var query = new GradeLevelTypeDescriptorQuery((int) source.GradeLevel.GetValueOrDefault());
            var assessedGradeLevelDescriptor = _genericRepository.Get(query);
            target.AssessedGradeLevelDescriptorId = assessedGradeLevelDescriptor.GradeLevelDescriptorId;
        }

        private void MapMinimumScore(CreateModel createModel, PerformanceLevelDescriptorEnum performanceLevelDescriptor,
            AssessmentPerformanceLevel assessmentPerformanceLevel)
        {
            switch (performanceLevelDescriptor)
            {
                case PerformanceLevelDescriptorEnum.Mastery:
                    assessmentPerformanceLevel.MinimumScore = createModel.Mastery.ToString();
                    break;
                case PerformanceLevelDescriptorEnum.NearMastery:
                    assessmentPerformanceLevel.MinimumScore = createModel.NearMastery.ToString();
                    break;
            }
        }

        private static void AddAssessmentPerformanceLevel(Data.Entities.Assessment assessment,
            AssessmentPerformanceLevel assessmentPerformanceLevel)
        {
            if (assessment.AssessmentPerformanceLevels.IsNullOrEmpty())
                assessment.AssessmentPerformanceLevels = new Collection<AssessmentPerformanceLevel>();

            assessment.AssessmentPerformanceLevels.Add(assessmentPerformanceLevel);
        }
    }
}
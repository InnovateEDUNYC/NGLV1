using System;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Assessment
{
    public interface IPerformanceLevelMapper
    {
        void Map(CreateModel source, AssessmentPerformanceLevel target);
        AssessmentPerformanceLevel Build(CreateModel source, Action<AssessmentPerformanceLevel> injectProperties);
        AssessmentPerformanceLevel Build(CreateModel source);
        AssessmentPerformanceLevel BuildWithPerformanceLevel(CreateModel source, Data.Entities.Assessment assessment, PerformanceLevelDescriptorEnum performanceLevelDescriptor);
    }
}

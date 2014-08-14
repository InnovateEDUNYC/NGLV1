using System;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Assessment
{
    public interface IPerformanceLevelMapper
    {
        AssessmentPerformanceLevel BuildWithPerformanceLevel(CreateModel source, Data.Entities.Assessment assessment, PerformanceLevelDescriptorEnum performanceLevelDescriptor);
    }
}

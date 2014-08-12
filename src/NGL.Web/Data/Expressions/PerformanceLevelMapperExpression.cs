using System;
using NGL.Web.Data.Entities;

namespace NGL.Web.Data.Expressions
{
    public class PerformanceLevelMapperExpression
    {
        public Action<AssessmentPerformanceLevel> Expression { get; set; }

        public PerformanceLevelMapperExpression(Assessment assessment, PerformanceLevelDescriptorEnum performanceLevel)
        {
            Expression = pl =>
            {
                pl.PerformanceLevelDescriptorId = (int) performanceLevel;
                pl.AcademicSubjectDescriptorId = assessment.AcademicSubjectDescriptorId;
                pl.Version = assessment.Version;
            };
        }
    }
}
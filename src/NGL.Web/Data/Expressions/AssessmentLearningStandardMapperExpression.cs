using System;
using Antlr.Runtime.Misc;
using NGL.Web.Data.Entities;

namespace NGL.Web.Data.Expressions
{
    public class AssessmentMapperExpression
    {
        public Action<AssessmentLearningStandard> Expression { get; set; }

        public AssessmentMapperExpression(Assessment assessment)
        {
            Expression = a =>
            {
                a.AcademicSubjectDescriptorId = assessment.AcademicSubjectDescriptorId;
                a.Version = assessment.Version;
            };
        }

    }
}
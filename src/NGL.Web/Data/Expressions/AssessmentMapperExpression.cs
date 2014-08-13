using System;
using NGL.Web.Data.Entities;

namespace NGL.Web.Data.Expressions
{
    public class AssessmentMapperExpression
    {
        public Action<AssessmentLearningStandard> LearningStandardExpression { get; set; }
        public Action<AssessmentSection> SectionExpression { get; set; }

        public AssessmentMapperExpression(Assessment assessment)
        {
            LearningStandardExpression = a =>
            {
                a.AcademicSubjectDescriptorId = assessment.AcademicSubjectDescriptorId;
                a.Version = assessment.Version;
            };

            SectionExpression = a =>
            {
                a.AcademicSubjectDescriptorId = assessment.AcademicSubjectDescriptorId;
                a.Version = assessment.Version;
            };
        }

    }
}
using System.Collections.ObjectModel;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Assessment
{
    public class CreateModelToAssessmentLearningStandardMapper : IAssessmentJoinMapper<AssessmentLearningStandard, Data.Entities.Assessment>
    {
        private Data.Entities.Assessment _assessment;

        public AssessmentLearningStandard Build(CreateModel source, Data.Entities.Assessment assessment)
        {
            _assessment = assessment;
            if (assessment.AssessmentLearningStandards.IsNullOrEmpty())
                assessment.AssessmentLearningStandards = new Collection<AssessmentLearningStandard>();

            var assessmentLearningStandard = Build(source);

            assessment.AssessmentLearningStandards.Add(assessmentLearningStandard);
            return assessmentLearningStandard;
        }

        private AssessmentLearningStandard Build(CreateModel source)
        {
            var target = new AssessmentLearningStandard();
            MapAssessment(target);
            MapLearningStandard(source, target);
            return target;
        }

        private void MapAssessment(AssessmentLearningStandard target)
        {
            target.AssessmentTitle = _assessment.AssessmentTitle;
            target.AssessedGradeLevelDescriptorId = _assessment.AssessedGradeLevelDescriptorId;
            target.AcademicSubjectDescriptorId = _assessment.AcademicSubjectDescriptorId;
            target.Version = _assessment.Version;
        }

        private void MapLearningStandard(CreateModel source, AssessmentLearningStandard target)
        {
            target.LearningStandardId = source.CommonCoreStandard;
        }
    }
}
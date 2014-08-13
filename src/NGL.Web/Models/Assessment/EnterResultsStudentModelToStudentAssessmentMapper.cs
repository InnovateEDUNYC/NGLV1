using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Assessment
{
    public class EnterResultsStudentModelToStudentAssessmentMapper
    {
        private readonly EnterResultsStudentModelToStudentAssessmentScoreResultMapper
            _enterResultsStudentModelToStudentAssessmentScoreResultMapper;

        public EnterResultsStudentModelToStudentAssessmentMapper(EnterResultsStudentModelToStudentAssessmentScoreResultMapper enterResultsStudentModelToStudentAssessmentScoreResultMapper)
        {
            _enterResultsStudentModelToStudentAssessmentScoreResultMapper = enterResultsStudentModelToStudentAssessmentScoreResultMapper;
        }

        public StudentAssessment Build(EnterResultsStudentModel enterResultsStudentModel, Data.Entities.Assessment assessment)
        {
            var target = new StudentAssessment
            {
                StudentUSI = enterResultsStudentModel.StudentUsi,
                AssessmentTitle = assessment.AssessmentTitle,
                AcademicSubjectDescriptorId = assessment.AcademicSubjectDescriptorId,
                AssessedGradeLevelDescriptorId = assessment.AssessedGradeLevelDescriptorId,
                Version = assessment.Version,
                AdministrationDate = assessment.AdministeredDate
            };

            var studentAssessmentScoreResult =
                _enterResultsStudentModelToStudentAssessmentScoreResultMapper.Build(enterResultsStudentModel, assessment);
            target.StudentAssessmentScoreResults.Add(studentAssessmentScoreResult);

            return target;
        }
    }
}
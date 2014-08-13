using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Assessment
{
    public class EnterResultsStudentModelToStudentAssessmentScoreResultMapper
    {
        public StudentAssessmentScoreResult Build(EnterResultsStudentModel source, Data.Entities.Assessment assessment)
        {
            return new StudentAssessmentScoreResult
            {
                StudentUSI = source.StudentUsi,
                Result = source.AssessmentResult ?? "",
                AssessmentReportingMethodTypeId = (int) AssessmentReportingMethodTypeEnum.Percentile,
                ResultDatatypeTypeId = (int) ResultDatatypeTypeEnum.Percentile,
                AssessmentTitle = assessment.AssessmentTitle,
                AcademicSubjectDescriptorId = assessment.AcademicSubjectDescriptorId,
                AssessedGradeLevelDescriptorId = assessment.AssessedGradeLevelDescriptorId,
                Version = assessment.Version,
                AdministrationDate = assessment.AdministeredDate
            };
        }
    }
}
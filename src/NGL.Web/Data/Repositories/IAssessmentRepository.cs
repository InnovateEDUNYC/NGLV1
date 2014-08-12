using System;
using System.Collections.Generic;
using NGL.Web.Data.Entities;
using NGL.Web.Models;
using NGL.Web.Models.Assessment;

namespace NGL.Web.Data.Repositories
{
    public interface IAssessmentRepository
    {
        IEnumerable<StudentAssessment> GetAssessmentResults(int studentUsi, DateTime startDate, DateTime endDate);
        IEnumerable<Assessment> GetAssessments();
        void Save(Assessment assessment, AssessmentPerformanceLevel nearMastery, AssessmentPerformanceLevel mastery);
        Assessment GetAssessmentForEnterResultsPost(int assessmentId);
        Assessment GetAssessmentForEnterResultsGet(int id);
        void AddStudentAssessment(Assessment assessment, EnterResultsStudentModel enterResultsStudentModel, IMapper<EnterResultsStudentModel, StudentAssessment> enterResultsStudentModelToStudentAssessmentMapper);
        void AddStudentAssessmentScoreResult(Assessment assessment, EnterResultsStudentModel enterResultsStudentModel, IMapper<EnterResultsStudentModel, StudentAssessmentScoreResult> enterResultsStudentModelToStudentAssessmentScoreResultMapper);
    }
}

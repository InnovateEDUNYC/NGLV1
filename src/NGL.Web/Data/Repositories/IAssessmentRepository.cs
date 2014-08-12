using System;
using System.Collections.Generic;
using NGL.Web.Data.Entities;

namespace NGL.Web.Data.Repositories
{
    public interface IAssessmentRepository
    {
        IEnumerable<StudentAssessment> GetAssessmentResults(int studentUsi, DateTime startDate, DateTime endDate);
        IEnumerable<Assessment> GetAssessments();
        Assessment GetAssessmentByAssessmentId(int assessmentId);
        void SaveStudentAssessment(StudentAssessment studentAssessment);
        void Save(Assessment assessment, AssessmentPerformanceLevel nearMastery, AssessmentPerformanceLevel mastery, AssessmentLearningStandard learningStandard);
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models;
using NGL.Web.Models.Assessment;

namespace NGL.Web.Data.Repositories
{
    public class AssessmentRepository : RepositoryBase, IAssessmentRepository
    {
        public AssessmentRepository(INglDbContext dbContext) : base(dbContext) { }

        public IEnumerable<StudentAssessment> GetAssessmentResults(int studentUsi, DateTime startDate, DateTime endDate)
        {
            return DbContext.Set<StudentAssessment>()
                .Where(
                    sa =>
                        sa.StudentUSI == studentUsi && sa.AdministrationDate >= startDate &&
                        sa.AdministrationDate <= endDate)
                .Include(sa => sa.Assessment)
                .Include(sa => sa.Assessment.AssessmentPerformanceLevels)
                .Include(sa => sa.Assessment.AssessmentLearningStandards.Select(als => als.LearningStandard))
                .Include(sa => sa.Assessment.AssessmentSections.Select(a => a.Section))
                .Include(sa => sa.StudentAssessmentScoreResults)
                .ToList();
        }

        public IEnumerable<Assessment> GetAssessments()
        {
            return DbContext.Set<Assessment>()
                .Where(
                    a =>
                        a.Id != null)
                .Include(a => a.AssessmentSections.Select(assessmentSection => assessmentSection.Section.Session))
                .ToList();
        }

        public Assessment GetAssessmentForEnterResultsPost(int assessmentId)
        {
            return DbContext.Set<Assessment>()
                .Where(
                    a =>
                        a.AssessmentIdentity == assessmentId)
                .Include(a => a.StudentAssessments)
                .Include(a => a.StudentAssessments.Select(sa => sa.StudentAssessmentScoreResults))
                .First();
        }

        public Assessment GetAssessmentForEnterResultsGet(int id)
        {
            var assessment = DbContext.Set<Assessment>()
                .Where(
                    a =>
                        a.AssessmentIdentity == id)
                .Include(a => a.AssessmentSections.Select(asa => asa.Section.StudentSectionAssociations.Select(s => s.Student)))
                .Include(a => a.AssessmentSections.Select(asa => asa.Section.Session))
                .Include(a => a.StudentAssessments.Select(sa => sa.StudentAssessmentScoreResults))
                .First();


            return assessment;
        }

        public void AddStudentAssessment(Assessment assessment, EnterResultsStudentModel enterResultsStudentModel, IMapper<EnterResultsStudentModel, StudentAssessment> mapper)
        {
            DbContext.Entry(mapper.Build(enterResultsStudentModel,
                sa =>
                {
                    sa.AssessmentTitle = assessment.AssessmentTitle;
                    sa.AcademicSubjectDescriptorId = assessment.AcademicSubjectDescriptorId;
                    sa.AssessedGradeLevelDescriptorId = assessment.AssessedGradeLevelDescriptorId;
                    sa.Version = assessment.Version;
                    sa.AdministrationDate = assessment.AdministeredDate;
                }));
        }

        public void Save(Assessment assessment, AssessmentPerformanceLevel nearMastery, AssessmentPerformanceLevel mastery)
        {
            DbContext.Set<Assessment>().Add(assessment);
            DbContext.Set<AssessmentPerformanceLevel>().Add(nearMastery);
            DbContext.Set<AssessmentPerformanceLevel>().Add(mastery);
            DbContext.Save();
        }

        public void AddStudentAssessmentScoreResult(Assessment assessment, EnterResultsStudentModel enterResultsStudentModel, IMapper<EnterResultsStudentModel, StudentAssessmentScoreResult> mapper)
        {
            DbContext.Entry(mapper.Build(enterResultsStudentModel,
                asr =>
                {
                    asr.AssessmentTitle = assessment.AssessmentTitle;
                    asr.AcademicSubjectDescriptorId = assessment.AcademicSubjectDescriptorId;
                    asr.AssessedGradeLevelDescriptorId = assessment.AssessedGradeLevelDescriptorId;
                    asr.Version = assessment.Version;
                    asr.AdministrationDate = assessment.AdministeredDate;
                }));
        }
    }
}
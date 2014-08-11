using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

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
    }
}
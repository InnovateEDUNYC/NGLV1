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

        public IEnumerable<Assessment> GetAssessmentResults(int studentUsi, DateTime startDate, DateTime endDate)
        {
            return DbContext.Set<Assessment>()
                .Where(a => a.AdministeredDate >= startDate && a.AdministeredDate <= endDate)
                .Include(a => a.StudentAssessments.Select(sa => sa.StudentAssessmentScoreResults))
                .Include(a => a.AssessmentPerformanceLevels)
                .Include(a => a.AssessmentLearningStandards.Select(als => als.LearningStandard)).ToList();
        }
    }
}
﻿using System;
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
                .Include(sa => sa.StudentAssessmentScoreResults)
                .ToList();
        }
    }
}
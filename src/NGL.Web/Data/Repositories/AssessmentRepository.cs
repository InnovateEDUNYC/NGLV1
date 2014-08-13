﻿using System;
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
                .Include(a => a.AssessmentLearningStandards.Select(als => als.LearningStandard))
                .ToList();
        }

        public Assessment GetAssessmentByAssessmentId(int assessmentId)
        {
            var assessment = DbContext.Set<Assessment>()
                .Where(
                    a =>
                        a.AssessmentIdentity == assessmentId)
                .Include(a => a.AssessmentSections.Select(asa => asa.Section.StudentSectionAssociations.Select(s => s.Student)))
                .Include(a => a.AssessmentSections.Select(asa => asa.Section.Session))
                .Include(a => a.StudentAssessments.Select(sa => sa.StudentAssessmentScoreResults))
                .Include(a => a.AssessmentLearningStandards.Select(als => als.LearningStandard))
                .FirstOrDefault();

            return assessment;
        }

        public void SaveStudentAssessment(StudentAssessment studentAssessment)
        {
            DbContext.Set<StudentAssessment>().Add(studentAssessment);
            DbContext.Set<StudentAssessmentScoreResult>().Add(studentAssessment.StudentAssessmentScoreResults.First());
        }

        public void Save(Assessment assessment, AssessmentPerformanceLevel nearMastery, AssessmentPerformanceLevel mastery, AssessmentLearningStandard learningStandard, AssessmentSection assessmentSection)
        {
            assessment.AssessmentSections.Add(assessmentSection);
            DbContext.Set<Assessment>().Add(assessment);
            DbContext.Set<AssessmentPerformanceLevel>().Add(nearMastery);
            DbContext.Set<AssessmentPerformanceLevel>().Add(mastery);
            DbContext.Set<AssessmentLearningStandard>().Add(learningStandard);
            DbContext.Set<AssessmentSection>().Add(assessmentSection);
            DbContext.Save();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Humanizer;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Assessment
{
    public class StudentAssessmentsToAssessmentResultModelMapper
    {
        public AssessmentResultModel Map(IEnumerable<StudentAssessment> studentAssessments, DateTime startDate, DateTime endDate)
        {
            var assessmentResultModel = new AssessmentResultModel();

            assessmentResultModel.AssessmentResultRows = studentAssessments.Select(sa => CreateAssessmentResultRow(sa, startDate, endDate)).ToList();

            return assessmentResultModel;
        }

        private AssessmentResultRowModel CreateAssessmentResultRow(StudentAssessment studentAssessment, DateTime startDate, DateTime endDate)
        {
            var results = new List<string>();

            while (startDate <= endDate)
            {
                if (studentAssessment.AdministrationDate == startDate)
                {
                    var result = GetPerformanceLevel(studentAssessment);
                    results.Add(result);
                }
                else
                {
                    results.Add(string.Empty);
                }
                startDate = startDate.AddDays(1);
            }

            var commonCoreStandard = studentAssessment.Assessment.AssessmentLearningStandards.First().LearningStandard.Description;
            var sectionCode = studentAssessment.Assessment.AssessmentSections.First().Section.UniqueSectionCode;

            return new AssessmentResultRowModel
            {
                CommonCoreStandard = commonCoreStandard,
                SectionCode = sectionCode,
                Results = results
            };
        }

        private string GetPerformanceLevel(StudentAssessment studentAssessment)
        {
            var studentScore = Convert.ToDecimal(studentAssessment.StudentAssessmentScoreResults.First().Result);

            var assessmentPerformanceLevels = studentAssessment.Assessment.AssessmentPerformanceLevels.ToList();
            var sortedPerformanceLevels = assessmentPerformanceLevels.OrderByDescending(apl => Convert.ToDecimal(apl.MinimumScore));

            var studentPerformanceLevel = sortedPerformanceLevels.FirstOrDefault(pl => studentScore >= Convert.ToDecimal(pl.MinimumScore));

            var result = PerformanceLevelDescriptorEnum.NotMastered;

            if (studentPerformanceLevel != null)
            {
                result = ((PerformanceLevelDescriptorEnum) studentPerformanceLevel.PerformanceLevelDescriptorId);
            }

            return result.Humanize();
        }
    }
}
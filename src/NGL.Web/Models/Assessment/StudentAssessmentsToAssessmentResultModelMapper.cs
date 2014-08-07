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

            while (startDate < endDate)
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

            return new AssessmentResultRowModel
            {
                CommonCodeStandard = studentAssessment.Assessment.AssessmentLearningStandards.First().LearningStandard.Description,
                Results = results
            };
        }

        private string GetPerformanceLevel(StudentAssessment studentAssessment)
        {
            var studentScore = Convert.ToInt32(studentAssessment.StudentAssessmentScoreResults.First().Result);

            var assessmentPerformanceLevels = studentAssessment.Assessment.AssessmentPerformanceLevels.ToList();
            var sortedPerformanceLevels = assessmentPerformanceLevels.OrderByDescending(apl => Convert.ToInt32(apl.MinimumScore));

            var studentPerformanceLevel = sortedPerformanceLevels.First(pl => studentScore >= Convert.ToInt32(pl.MinimumScore));

            return ((PerformanceLevelDescriptorEnum) studentPerformanceLevel.PerformanceLevelDescriptorId).Humanize();
        }
    }
}
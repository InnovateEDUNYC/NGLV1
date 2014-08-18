using System;
using System.Collections.Generic;
using System.Linq;
using Humanizer;
using Microsoft.Ajax.Utilities;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Models.Assessment
{
    public class StudentAssessmentsToAssessmentResultModelMapper
    {
        private readonly IGenericRepository _genericRepository;

        public StudentAssessmentsToAssessmentResultModelMapper(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public AssessmentResultModel Map(IEnumerable<StudentAssessment> studentAssessments, DateTime startDate, DateTime endDate)
        {
            var assessmentResultModel = new AssessmentResultModel
            {
                DateRange = startDate.ToShortDateString() + " - " + endDate.ToShortDateString(),
                AssessmentResultRows =
                    studentAssessments.Select(sa => CreateAssessmentResultRow(sa, startDate, endDate)).ToList()
            };

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

            var assessment = studentAssessment.Assessment;

            var commonCoreStandard = assessment.AssessmentLearningStandards.First().LearningStandard.Description;
            var sectionCode = assessment.AssessmentSections.First().Section.UniqueSectionCode;
            var grade = studentAssessment.StudentAssessmentScoreResults.First().Result;
            var assessmentTitle = assessment.AssessmentTitle;
            var date = studentAssessment.AdministrationDate;

            var assessmentCategoryType = _genericRepository.Get<AssessmentCategoryType>(act => act.AssessmentCategoryTypeId == assessment.AssessmentCategoryTypeId);

            return new AssessmentResultRowModel
            {
                CommonCoreStandard = commonCoreStandard,
                SectionCode = sectionCode,
                Results = results,
                Grade = grade,
                AssessmentTitle = assessmentTitle,
                Date = date,
                AssessmentTypeDescription = assessmentCategoryType.ShortDescription
            };
        }

        private string GetPerformanceLevel(StudentAssessment studentAssessment)
        {
            var studentScore = Convert.ToDecimal(studentAssessment.StudentAssessmentScoreResults.First().Result);

            var assessmentPerformanceLevels = studentAssessment.Assessment.AssessmentPerformanceLevels.ToList();
            var sortedPerformanceLevels = assessmentPerformanceLevels.OrderByDescending(apl => Convert.ToDecimal(apl.MinimumScore));

            System.Diagnostics.Debug.WriteLine(assessmentPerformanceLevels);

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
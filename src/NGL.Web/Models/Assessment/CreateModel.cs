using System;
using System.Collections.Generic;
using ChameleonForms.Attributes;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Assessment
{
    public class CreateModel
    {
        public CreateModel()
        {
            CommonCoreStandards = new List<CommonCoreStandardListItemModel>();
        }

        public int SessionId { get; set; }
        public string Session { get; set; }
        public int SectionId { get; set; }
        public string Section { get; set; }
        public string AssessmentTitle { get; set; }
        public DateTime? AdministeredDate { get; set; }
        public AssessmentCategoryTypeEnum? QuestionType { get; set; }
        public GradeLevelTypeEnum? GradeLevel { get; set; }

        public List<CommonCoreStandardListItemModel> CommonCoreStandards { get; set; }

        [ExistsIn("CommonCoreStandards", "LearningStandardId", "Description", false)]
        public string CommonCoreStandard { get; set; }

        public AssessmentReportingMethodTypeEnum ReportingMethod { get; set; }
        public decimal? Mastery { get; set; }
        public decimal? NearMastery { get; set; }

        public static CreateModel CreateNewWith(List<CommonCoreStandardListItemModel> commonCoreStandards)
        {
            return new CreateModel
            {
                CommonCoreStandards = commonCoreStandards
            };
        }
    }
}
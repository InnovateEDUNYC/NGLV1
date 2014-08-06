using System;
using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Assessment
{
    public class CreateModel
    {
        public short SchoolYear { get; set; }
        public int Term { get; set; }
        public string Session { get; set; }

        public int SectionId { get; set; }
        
        [StringLength(60)]
        public string AssessmentTitle { get; set; }

        public DateTime AdministeredDate { get; set; }

        public AssessmentCategoryTypeEnum QuestionType { get; set; }
        public GradeLevelTypeEnum GradeLevel { get; set; }

    }
}
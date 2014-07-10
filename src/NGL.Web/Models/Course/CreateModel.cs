using System;
using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Course
{
    public class CreateModel
    {
        [Required]
        public string CourseCode { get; set; }

        [Required]
        public string CourseTitle { get; set; }

        [Required]
        public int NumberOfParts { get; set; }
        public AcademicSubjectDescriptorEnum? AcademicSubject { get; set; }
        public string CourseDescription { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime? DateCourseAdopted { get; set; }
        public bool? HighSchoolCourseRequirement { get; set; }
        public CourseGPAApplicabilityTypeEnum? CourseGPAApplicability { get; set; }
        public CourseDefinedByTypeEnum? CourseDefinedBy { get; set; }
        public CreditTypeEnum? MinimumAvailableCreditType { get; set; }
        public decimal? MinimumAvailableCreditConversion { get; set; }
        public decimal? MinimumAvailableCredit { get; set; }
        public CreditTypeEnum? MaximumAvailableCreditType { get; set; }
        public decimal? MaximumAvailableCreditConversion { get; set; }
        public decimal? MaximumAvailableCredit { get; set; }
        public CareerPathwayTypeEnum? CareerPathway { get; set; }
        public int? TimeRequiredForCompletion { get; set; }

    }
}
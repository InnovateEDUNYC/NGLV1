using System;
using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Course
{
    public class CreateModel
    {
        [Required]
        [StringLength(60)]
        public string CourseCode { get; set; }

        [Required]
        [StringLength(60)]
        public string CourseTitle { get; set; }

        [Required]
        public int NumberOfParts { get; set; }
        public AcademicSubjectDescriptorEnum? AcademicSubject { get; set; }

        [StringLength(20)]
        public string CourseDescription { get; set; }
        public DateTime? DateCourseAdopted { get; set; }
        public bool? HighSchoolCourseRequirement { get; set; }
        public CourseGPAApplicabilityTypeEnum? CourseGPAApplicability { get; set; }
        public CourseDefinedByTypeEnum? CourseDefinedBy { get; set; }
        public CreditTypeEnum? MinimumAvailableCreditType { get; set; }

        [RegularExpression(@"^\d+.\d{0,2}$")]
        [Range(0, 9999999.99)]
        public decimal? MinimumAvailableCreditConversion { get; set; }

        [RegularExpression(@"^\d+.\d{0,2}$")]
        [Range(0, 9999999.99)]
        public decimal? MinimumAvailableCredit { get; set; }
        public CreditTypeEnum? MaximumAvailableCreditType { get; set; }

        [RegularExpression(@"^\d+.\d{0,2}$")]
        [Range(0, 9999999.99)]
        public decimal? MaximumAvailableCreditConversion { get; set; }

        [RegularExpression(@"^\d+.\d{0,2}$")]
        [Range(0, 9999999.99)]
        public decimal? MaximumAvailableCredit { get; set; }
        public CareerPathwayTypeEnum? CareerPathway { get; set; }
        public int? TimeRequiredForCompletion { get; set; }

    }
}
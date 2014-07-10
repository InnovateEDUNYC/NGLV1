using System;
using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Course
{
    public class CreateModel
    {
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public int NumberOfParts { get; set; }
        public AcademicSubjectDescriptorEnum? AcademicSubject { get; set; }
        public string CourseDescription { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime? DateCourseAdopted { get; set; }
        public bool? HighSchoolCourseRequirement { get; set; }
        public CourseGPAApplicabilityTypeEnum? CourseGPAApplicability { get; set; }
        public CourseDefinedByTypeEnum? CourseDefinedBy { get; set; }
        public int? MinimumAvailableCreditTypeId { get; set; }
        public decimal? MinimumAvailableCreditConversion { get; set; }
        public decimal? MinimumAvailableCredit { get; set; }
        public int? MaximumAvailableCreditTypeId { get; set; }
        public decimal? MaximumAvailableCreditConversion { get; set; }
        public decimal? MaximumAvailableCredit { get; set; }
        public CareerPathwayTypeEnum? CareerPathway { get; set; }
        public int? TimeRequiredForCompletion { get; set; }

    }
}
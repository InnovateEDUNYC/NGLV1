using System;
using System.Collections.Generic;
using NGL.Web.Models.CourseOffering;

namespace NGL.Web.Models.Course
{
    public class CourseModel
    {
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public int NumberOfParts { get; set; }
        public int? AcademicSubjectDescriptorId { get; set; }
        public string CourseDescription { get; set; }
        public DateTime? DateCourseAdopted { get; set; }
        public bool? HighSchoolCourseRequirement { get; set; }
        public int? CourseGPAApplicabilityTypeId { get; set; }
        public int? CourseDefinedByTypeId { get; set; }
        public int? MinimumAvailableCreditTypeId { get; set; }
        public decimal? MinimumAvailableCreditConversion { get; set; }
        public decimal? MinimumAvailableCredit { get; set; }
        public int? MaximumAvailableCreditTypeId { get; set; }
        public decimal? MaximumAvailableCreditConversion { get; set; }
        public decimal? MaximumAvailableCredit { get; set; }
        public int? CareerPathwayTypeId { get; set; }
        public int? TimeRequiredForCompletion { get; set; }

        public ICollection<CourseOfferingModel> CourseOfferings { get; set; }
    }
}
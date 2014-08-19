using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChameleonForms.Attributes;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Course
{
    public class CreateModel
    {
        public CreateModel()
        {
            ParentCourseList = new List<ParentCourseListItemModel>();
        }

        public List<ParentCourseListItemModel> ParentCourseList { get; set; }

        [ExistsIn("ParentCourseList", "ParentCourseId", "ParentCourseTitle", false)]
        [Display(Name="Parent Course")]
        public Guid? ParentCourseId { get; set; }

        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public int? NumberOfParts { get; set; }
        public AcademicSubjectDescriptorEnum? AcademicSubject { get; set; }
        public string CourseDescription { get; set; }
        public DateTime? DateCourseAdopted { get; set; }
        public bool? HighSchoolCourseRequirement { get; set; }
        public CourseGPAApplicabilityTypeEnum? CourseGPAApplicability { get; set; }
        public CourseDefinedByTypeEnum? CourseDefinedBy { get; set; }
        public CreditTypeEnum? MinimumAvailableCreditType { get; set; }

        [Credit]
        public decimal? MinimumAvailableCreditConversion { get; set; }

        [Credit]
        public decimal? MinimumAvailableCredit { get; set; }

        public CreditTypeEnum? MaximumAvailableCreditType { get; set; }

        [Credit]
        public decimal? MaximumAvailableCreditConversion { get; set; }

        [Credit]
        public decimal? MaximumAvailableCredit { get; set; }

        public CareerPathwayTypeEnum? CareerPathway { get; set; }
        public int? TimeRequiredForCompletion { get; set; }

        public static CreateModel CreateNewWith(List<ParentCourseListItemModel> parentCourseList)
        {
            return new CreateModel
            {
                ParentCourseList = parentCourseList
            };
        }

    }
}
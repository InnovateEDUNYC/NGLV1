//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NGL.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course
    {
        public Course()
        {
    		this.Id = System.Guid.NewGuid();
    		this.LastModifiedDate = System.DateTime.Now;
    		this.CreateDate = System.DateTime.Now;
            this.CourseCompetencyLevels = new HashSet<CourseCompetencyLevel>();
            this.CourseGradeLevels = new HashSet<CourseGradeLevel>();
            this.CourseIdentificationCodes = new HashSet<CourseIdentificationCode>();
            this.CourseLearningObjectives = new HashSet<CourseLearningObjective>();
            this.CourseLearningStandards = new HashSet<CourseLearningStandard>();
            this.CourseLevelCharacteristics = new HashSet<CourseLevelCharacteristic>();
            this.CourseOfferings = new HashSet<CourseOffering>();
            this.GraduationPlanCreditsByCourseCourses = new HashSet<GraduationPlanCreditsByCourseCourse>();
        }
    
        public int EducationOrganizationId { get; set; }
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public int NumberOfParts { get; set; }
        public Nullable<int> AcademicSubjectDescriptorId { get; set; }
        public string CourseDescription { get; set; }
        public Nullable<System.DateTime> DateCourseAdopted { get; set; }
        public Nullable<bool> HighSchoolCourseRequirement { get; set; }
        public Nullable<int> CourseGPAApplicabilityTypeId { get; set; }
        public Nullable<int> CourseDefinedByTypeId { get; set; }
        public Nullable<int> MinimumAvailableCreditTypeId { get; set; }
        public Nullable<decimal> MinimumAvailableCreditConversion { get; set; }
        public Nullable<decimal> MinimumAvailableCredit { get; set; }
        public Nullable<int> MaximumAvailableCreditTypeId { get; set; }
        public Nullable<decimal> MaximumAvailableCreditConversion { get; set; }
        public Nullable<decimal> MaximumAvailableCredit { get; set; }
        public Nullable<int> CareerPathwayTypeId { get; set; }
        public Nullable<int> TimeRequiredForCompletion { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int CourseIdentity { get; set; }
        public System.Guid ParentCourseId { get; set; }
    
        public virtual AcademicSubjectDescriptor AcademicSubjectDescriptor { get; set; }
        public virtual CareerPathwayType CareerPathwayType { get; set; }
        public virtual CourseDefinedByType CourseDefinedByType { get; set; }
        public virtual CourseGPAApplicabilityType CourseGPAApplicabilityType { get; set; }
        public virtual CreditType CreditType { get; set; }
        public virtual CreditType CreditType1 { get; set; }
        public virtual EducationOrganization EducationOrganization { get; set; }
        public virtual ICollection<CourseCompetencyLevel> CourseCompetencyLevels { get; set; }
        public virtual ICollection<CourseGradeLevel> CourseGradeLevels { get; set; }
        public virtual ICollection<CourseIdentificationCode> CourseIdentificationCodes { get; set; }
        public virtual ICollection<CourseLearningObjective> CourseLearningObjectives { get; set; }
        public virtual ICollection<CourseLearningStandard> CourseLearningStandards { get; set; }
        public virtual ICollection<CourseLevelCharacteristic> CourseLevelCharacteristics { get; set; }
        public virtual ICollection<CourseOffering> CourseOfferings { get; set; }
        public virtual ICollection<GraduationPlanCreditsByCourseCourse> GraduationPlanCreditsByCourseCourses { get; set; }
        public virtual ParentCourse ParentCourse { get; set; }
    }
}

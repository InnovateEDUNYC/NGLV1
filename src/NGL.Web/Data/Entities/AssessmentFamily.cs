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
    
    public partial class AssessmentFamily
    {
        public AssessmentFamily()
        {
            this.Assessments = new HashSet<Assessment>();
            this.AssessmentFamilyLanguages = new HashSet<AssessmentFamilyLanguage>();
            this.AssessmentFamily1 = new HashSet<AssessmentFamily>();
            this.AssessmentFamilyAssessmentPeriods = new HashSet<AssessmentFamilyAssessmentPeriod>();
            this.AssessmentFamilyIdentificationCodes = new HashSet<AssessmentFamilyIdentificationCode>();
        }
    
        public string AssessmentFamilyTitle { get; set; }
        public Nullable<int> AcademicSubjectDescriptorId { get; set; }
        public Nullable<int> AssessedGradeLevelDescriptorId { get; set; }
        public Nullable<int> Version { get; set; }
        public Nullable<int> AssessmentCategoryTypeId { get; set; }
        public Nullable<int> LowestAssessedGradeLevelDescriptorId { get; set; }
        public Nullable<System.DateTime> RevisionDate { get; set; }
        public string Nomenclature { get; set; }
        public string ParentAssessmentFamilyTitle { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual AcademicSubjectDescriptor AcademicSubjectDescriptor { get; set; }
        public virtual ICollection<Assessment> Assessments { get; set; }
        public virtual AssessmentCategoryType AssessmentCategoryType { get; set; }
        public virtual ICollection<AssessmentFamilyLanguage> AssessmentFamilyLanguages { get; set; }
        public virtual GradeLevelDescriptor GradeLevelDescriptor { get; set; }
        public virtual ICollection<AssessmentFamily> AssessmentFamily1 { get; set; }
        public virtual AssessmentFamily AssessmentFamily2 { get; set; }
        public virtual GradeLevelDescriptor GradeLevelDescriptor1 { get; set; }
        public virtual ICollection<AssessmentFamilyAssessmentPeriod> AssessmentFamilyAssessmentPeriods { get; set; }
        public virtual AssessmentFamilyContentStandard AssessmentFamilyContentStandard { get; set; }
        public virtual ICollection<AssessmentFamilyIdentificationCode> AssessmentFamilyIdentificationCodes { get; set; }
    }
}
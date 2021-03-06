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
    
    public partial class LearningStandard
    {
        public LearningStandard()
        {
    		this.Id = System.Guid.NewGuid();
    		this.LastModifiedDate = System.DateTime.Now;
    		this.CreateDate = System.DateTime.Now;
            this.AssessmentItemLearningStandards = new HashSet<AssessmentItemLearningStandard>();
            this.CourseLearningStandards = new HashSet<CourseLearningStandard>();
            this.EducationContents = new HashSet<EducationContent>();
            this.GradebookEntryLearningStandards = new HashSet<GradebookEntryLearningStandard>();
            this.LearningObjectiveLearningStandards = new HashSet<LearningObjectiveLearningStandard>();
            this.LearningStandard1 = new HashSet<LearningStandard>();
            this.LearningStandardIdentificationCodes = new HashSet<LearningStandardIdentificationCode>();
            this.LearningStandardPrerequisiteLearningStandards = new HashSet<LearningStandardPrerequisiteLearningStandard>();
            this.LearningStandardPrerequisiteLearningStandards1 = new HashSet<LearningStandardPrerequisiteLearningStandard>();
            this.ObjectiveAssessmentLearningStandards = new HashSet<ObjectiveAssessmentLearningStandard>();
            this.ProgramLearningStandards = new HashSet<ProgramLearningStandard>();
            this.AssessmentLearningStandards = new HashSet<AssessmentLearningStandard>();
        }
    
        public string LearningStandardId { get; set; }
        public string ParentLearningStandardId { get; set; }
        public string Description { get; set; }
        public string LearningStandardItemCode { get; set; }
        public string URI { get; set; }
        public int GradeLevelDescriptorId { get; set; }
        public int AcademicSubjectDescriptorId { get; set; }
        public string CourseTitle { get; set; }
        public string SuccessCriteria { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int LearningStandardIdentity { get; set; }
    
        public virtual AcademicSubjectDescriptor AcademicSubjectDescriptor { get; set; }
        public virtual ICollection<AssessmentItemLearningStandard> AssessmentItemLearningStandards { get; set; }
        public virtual ICollection<CourseLearningStandard> CourseLearningStandards { get; set; }
        public virtual ICollection<EducationContent> EducationContents { get; set; }
        public virtual ICollection<GradebookEntryLearningStandard> GradebookEntryLearningStandards { get; set; }
        public virtual GradeLevelDescriptor GradeLevelDescriptor { get; set; }
        public virtual ICollection<LearningObjectiveLearningStandard> LearningObjectiveLearningStandards { get; set; }
        public virtual ICollection<LearningStandard> LearningStandard1 { get; set; }
        public virtual LearningStandard LearningStandard2 { get; set; }
        public virtual LearningStandardContentStandard LearningStandardContentStandard { get; set; }
        public virtual ICollection<LearningStandardIdentificationCode> LearningStandardIdentificationCodes { get; set; }
        public virtual ICollection<LearningStandardPrerequisiteLearningStandard> LearningStandardPrerequisiteLearningStandards { get; set; }
        public virtual ICollection<LearningStandardPrerequisiteLearningStandard> LearningStandardPrerequisiteLearningStandards1 { get; set; }
        public virtual ICollection<ObjectiveAssessmentLearningStandard> ObjectiveAssessmentLearningStandards { get; set; }
        public virtual ICollection<ProgramLearningStandard> ProgramLearningStandards { get; set; }
        public virtual ICollection<AssessmentLearningStandard> AssessmentLearningStandards { get; set; }
    }
}

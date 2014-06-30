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
    
    public partial class LearningObjective
    {
        public LearningObjective()
        {
            this.CourseLearningObjectives = new HashSet<CourseLearningObjective>();
            this.GradebookEntryLearningObjectives = new HashSet<GradebookEntryLearningObjective>();
            this.LearningObjective1 = new HashSet<LearningObjective>();
            this.LearningObjectiveLearningStandards = new HashSet<LearningObjectiveLearningStandard>();
            this.ObjectiveAssessmentLearningObjectives = new HashSet<ObjectiveAssessmentLearningObjective>();
            this.ProgramLearningObjectives = new HashSet<ProgramLearningObjective>();
            this.StudentLearningObjectives = new HashSet<StudentLearningObjective>();
        }
    
        public string Objective { get; set; }
        public int AcademicSubjectDescriptorId { get; set; }
        public int ObjectiveGradeLevelDescriptorId { get; set; }
        public string LearningObjectiveId { get; set; }
        public string Description { get; set; }
        public string ParentObjective { get; set; }
        public Nullable<int> ParentAcademicSubjectDescriptorId { get; set; }
        public Nullable<int> ParentObjectiveGradeLevelDescriptorId { get; set; }
        public string Nomenclature { get; set; }
        public string SuccessCriteria { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual AcademicSubjectDescriptor AcademicSubjectDescriptor { get; set; }
        public virtual ICollection<CourseLearningObjective> CourseLearningObjectives { get; set; }
        public virtual ICollection<GradebookEntryLearningObjective> GradebookEntryLearningObjectives { get; set; }
        public virtual GradeLevelDescriptor GradeLevelDescriptor { get; set; }
        public virtual ICollection<LearningObjective> LearningObjective1 { get; set; }
        public virtual LearningObjective LearningObjective2 { get; set; }
        public virtual LearningObjectiveContentStandard LearningObjectiveContentStandard { get; set; }
        public virtual ICollection<LearningObjectiveLearningStandard> LearningObjectiveLearningStandards { get; set; }
        public virtual ICollection<ObjectiveAssessmentLearningObjective> ObjectiveAssessmentLearningObjectives { get; set; }
        public virtual ICollection<ProgramLearningObjective> ProgramLearningObjectives { get; set; }
        public virtual ICollection<StudentLearningObjective> StudentLearningObjectives { get; set; }
    }
}
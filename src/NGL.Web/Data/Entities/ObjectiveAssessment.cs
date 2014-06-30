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
    
    public partial class ObjectiveAssessment
    {
        public ObjectiveAssessment()
        {
            this.ObjectiveAssessment1 = new HashSet<ObjectiveAssessment>();
            this.ObjectiveAssessmentAssessmentItems = new HashSet<ObjectiveAssessmentAssessmentItem>();
            this.ObjectiveAssessmentLearningObjectives = new HashSet<ObjectiveAssessmentLearningObjective>();
            this.ObjectiveAssessmentLearningStandards = new HashSet<ObjectiveAssessmentLearningStandard>();
            this.ObjectiveAssessmentPerformanceLevels = new HashSet<ObjectiveAssessmentPerformanceLevel>();
            this.StudentAssessmentStudentObjectiveAssessments = new HashSet<StudentAssessmentStudentObjectiveAssessment>();
        }
    
        public string AssessmentTitle { get; set; }
        public int AcademicSubjectDescriptorId { get; set; }
        public int AssessedGradeLevelDescriptorId { get; set; }
        public int Version { get; set; }
        public string IdentificationCode { get; set; }
        public string ParentIdentificationCode { get; set; }
        public Nullable<int> MaxRawScore { get; set; }
        public Nullable<decimal> PercentOfAssessment { get; set; }
        public string Nomenclature { get; set; }
        public string Description { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual Assessment Assessment { get; set; }
        public virtual ICollection<ObjectiveAssessment> ObjectiveAssessment1 { get; set; }
        public virtual ObjectiveAssessment ObjectiveAssessment2 { get; set; }
        public virtual ICollection<ObjectiveAssessmentAssessmentItem> ObjectiveAssessmentAssessmentItems { get; set; }
        public virtual ICollection<ObjectiveAssessmentLearningObjective> ObjectiveAssessmentLearningObjectives { get; set; }
        public virtual ICollection<ObjectiveAssessmentLearningStandard> ObjectiveAssessmentLearningStandards { get; set; }
        public virtual ICollection<ObjectiveAssessmentPerformanceLevel> ObjectiveAssessmentPerformanceLevels { get; set; }
        public virtual ICollection<StudentAssessmentStudentObjectiveAssessment> StudentAssessmentStudentObjectiveAssessments { get; set; }
    }
}

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
    
    public partial class ObjectiveAssessmentLearningObjective
    {
        public string AssessmentTitle { get; set; }
        public int AcademicSubjectDescriptorId { get; set; }
        public int AssessedGradeLevelDescriptorId { get; set; }
        public int Version { get; set; }
        public string IdentificationCode { get; set; }
        public string Objective { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual LearningObjective LearningObjective { get; set; }
        public virtual ObjectiveAssessment ObjectiveAssessment { get; set; }
    }
}

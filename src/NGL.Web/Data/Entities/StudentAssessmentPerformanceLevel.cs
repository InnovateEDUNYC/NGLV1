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
    
    public partial class StudentAssessmentPerformanceLevel
    {
        public int StudentUSI { get; set; }
        public string AssessmentTitle { get; set; }
        public int AcademicSubjectDescriptorId { get; set; }
        public int AssessedGradeLevelDescriptorId { get; set; }
        public int Version { get; set; }
        public System.DateTime AdministrationDate { get; set; }
        public int PerformanceLevelDescriptorId { get; set; }
        public bool PerformanceLevelMet { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual PerformanceLevelDescriptor PerformanceLevelDescriptor { get; set; }
        public virtual StudentAssessment StudentAssessment { get; set; }
    }
}

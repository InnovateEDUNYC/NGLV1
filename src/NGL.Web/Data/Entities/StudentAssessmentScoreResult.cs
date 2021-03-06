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
    
    public partial class StudentAssessmentScoreResult
    {
        public StudentAssessmentScoreResult()
        {
    		this.CreateDate = System.DateTime.Now;
        }
    
        public int StudentUSI { get; set; }
        public string AssessmentTitle { get; set; }
        public int AcademicSubjectDescriptorId { get; set; }
        public int AssessedGradeLevelDescriptorId { get; set; }
        public int Version { get; set; }
        public System.DateTime AdministrationDate { get; set; }
        public int AssessmentReportingMethodTypeId { get; set; }
        public string Result { get; set; }
        public int ResultDatatypeTypeId { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int StudentAssessmentScoreResultIdentity { get; set; }
    
        public virtual AssessmentReportingMethodType AssessmentReportingMethodType { get; set; }
        public virtual ResultDatatypeType ResultDatatypeType { get; set; }
        public virtual StudentAssessment StudentAssessment { get; set; }
    }
}

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
    
    public partial class ReportCardStudentCompetencyObjective
    {
        public int StudentUSI { get; set; }
        public int GradingPeriodEducationOrganizationId { get; set; }
        public int GradingPeriodDescriptorId { get; set; }
        public System.DateTime GradingPeriodBeginDate { get; set; }
        public string Objective { get; set; }
        public int ObjectiveGradeLevelDescriptorId { get; set; }
        public int EducationOrganizationId { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual ReportCard ReportCard { get; set; }
        public virtual StudentCompetencyObjective StudentCompetencyObjective { get; set; }
    }
}

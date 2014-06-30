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
    
    public partial class StudentMigrantEducationProgramAssociation
    {
        public int StudentUSI { get; set; }
        public int ProgramTypeId { get; set; }
        public int ProgramEducationOrganizationId { get; set; }
        public System.DateTime BeginDate { get; set; }
        public bool PriorityForServices { get; set; }
        public System.DateTime LastQualifyingMove { get; set; }
        public Nullable<int> ContinuationOfServicesReasonDescriptorId { get; set; }
        public Nullable<System.DateTime> USInitialEntry { get; set; }
        public Nullable<System.DateTime> USMostRecentEntry { get; set; }
        public Nullable<System.DateTime> USInitialSchoolEntry { get; set; }
        public string ProgramName { get; set; }
    
        public virtual ContinuationOfServicesReasonDescriptor ContinuationOfServicesReasonDescriptor { get; set; }
        public virtual StudentProgramAssociation StudentProgramAssociation { get; set; }
    }
}
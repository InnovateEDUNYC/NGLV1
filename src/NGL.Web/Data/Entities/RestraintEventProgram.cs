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
    
    public partial class RestraintEventProgram
    {
        public int StudentUSI { get; set; }
        public int SchoolId { get; set; }
        public string RestraintEventIdentifier { get; set; }
        public System.DateTime EventDate { get; set; }
        public int ProgramTypeId { get; set; }
        public string ProgramName { get; set; }
        public int EducationOrganizationId { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual Program Program { get; set; }
        public virtual RestraintEvent RestraintEvent { get; set; }
    }
}

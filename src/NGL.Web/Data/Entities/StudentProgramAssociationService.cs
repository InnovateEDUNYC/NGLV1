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
    
    public partial class StudentProgramAssociationService
    {
        public int StudentUSI { get; set; }
        public int ProgramTypeId { get; set; }
        public int ProgramEducationOrganizationId { get; set; }
        public System.DateTime BeginDate { get; set; }
        public int ServiceDescriptorId { get; set; }
        public string ProgramName { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual ServiceDescriptor ServiceDescriptor { get; set; }
        public virtual StudentProgramAssociation StudentProgramAssociation { get; set; }
    }
}
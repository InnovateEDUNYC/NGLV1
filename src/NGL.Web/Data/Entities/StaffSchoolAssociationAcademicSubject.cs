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
    
    public partial class StaffSchoolAssociationAcademicSubject
    {
        public int StaffUSI { get; set; }
        public int ProgramAssignmentDescriptorId { get; set; }
        public int SchoolId { get; set; }
        public int AcademicSubjectDescriptorId { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual AcademicSubjectDescriptor AcademicSubjectDescriptor { get; set; }
        public virtual StaffSchoolAssociation StaffSchoolAssociation { get; set; }
    }
}
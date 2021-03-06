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
    
    public partial class StaffSectionAssociation
    {
        public StaffSectionAssociation()
        {
    		this.Id = System.Guid.NewGuid();
    		this.LastModifiedDate = System.DateTime.Now;
    		this.CreateDate = System.DateTime.Now;
        }
    
        public int StaffUSI { get; set; }
        public int SchoolId { get; set; }
        public string ClassPeriodName { get; set; }
        public string ClassroomIdentificationCode { get; set; }
        public string LocalCourseCode { get; set; }
        public int TermTypeId { get; set; }
        public short SchoolYear { get; set; }
        public int ClassroomPositionDescriptorId { get; set; }
        public Nullable<System.DateTime> BeginDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<bool> HighlyQualifiedTeacher { get; set; }
        public Nullable<bool> TeacherStudentDataLinkExclusion { get; set; }
        public Nullable<decimal> PercentageContribution { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int StaffSectionAssociationIdentity { get; set; }
    
        public virtual ClassroomPositionDescriptor ClassroomPositionDescriptor { get; set; }
        public virtual Section Section { get; set; }
        public virtual Staff Staff { get; set; }
    }
}

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
    
    public partial class GraduationPlan
    {
        public GraduationPlan()
        {
    		this.Id = System.Guid.NewGuid();
    		this.LastModifiedDate = System.DateTime.Now;
    		this.CreateDate = System.DateTime.Now;
            this.GraduationPlanCreditsByCourses = new HashSet<GraduationPlanCreditsByCourse>();
            this.GraduationPlanCreditsBySubjects = new HashSet<GraduationPlanCreditsBySubject>();
            this.StudentSchoolAssociations = new HashSet<StudentSchoolAssociation>();
        }
    
        public int EducationOrganizationId { get; set; }
        public Nullable<bool> IndividualPlan { get; set; }
        public decimal TotalRequiredCredit { get; set; }
        public Nullable<int> TotalRequiredCreditTypeId { get; set; }
        public Nullable<decimal> TotalRequiredCreditConversion { get; set; }
        public int GraduationPlanTypeDescriptorId { get; set; }
        public short GraduationSchoolYear { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual CreditType CreditType { get; set; }
        public virtual EducationOrganization EducationOrganization { get; set; }
        public virtual GraduationPlanTypeDescriptor GraduationPlanTypeDescriptor { get; set; }
        public virtual SchoolYearType SchoolYearType { get; set; }
        public virtual ICollection<GraduationPlanCreditsByCourse> GraduationPlanCreditsByCourses { get; set; }
        public virtual ICollection<GraduationPlanCreditsBySubject> GraduationPlanCreditsBySubjects { get; set; }
        public virtual ICollection<StudentSchoolAssociation> StudentSchoolAssociations { get; set; }
    }
}

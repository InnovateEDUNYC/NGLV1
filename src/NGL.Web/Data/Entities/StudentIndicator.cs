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
    
    public partial class StudentIndicator
    {
        public int StudentUSI { get; set; }
        public string IndicatorName { get; set; }
        public string Indicator { get; set; }
        public string IndicatorGroup { get; set; }
        public Nullable<System.DateTime> BeginDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string DesignatedBy { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual Student Student { get; set; }
    }
}

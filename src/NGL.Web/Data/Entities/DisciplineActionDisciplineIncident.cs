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
    
    public partial class DisciplineActionDisciplineIncident
    {
        public DisciplineActionDisciplineIncident()
        {
    		this.CreateDate = System.DateTime.Now;
        }
    
        public int StudentUSI { get; set; }
        public string DisciplineActionIdentifier { get; set; }
        public System.DateTime DisciplineDate { get; set; }
        public int SchoolId { get; set; }
        public string IncidentIdentifier { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual DisciplineAction DisciplineAction { get; set; }
        public virtual DisciplineIncident DisciplineIncident { get; set; }
    }
}

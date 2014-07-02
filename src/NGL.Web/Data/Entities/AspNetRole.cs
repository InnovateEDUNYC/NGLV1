using System.ComponentModel.DataAnnotations.Schema;

namespace NGL.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    [Table("AspNetRoles", Schema = "dbo")]
    public partial class AspNetRole
    {
        public AspNetRole()
        {
            this.AspNetUsers = new HashSet<AspNetUser>();
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}

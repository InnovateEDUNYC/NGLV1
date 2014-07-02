using System.ComponentModel.DataAnnotations.Schema;

namespace NGL.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    [Table("AspNetUserLogin", Schema = "dbo")]
    public partial class AspNetUserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}

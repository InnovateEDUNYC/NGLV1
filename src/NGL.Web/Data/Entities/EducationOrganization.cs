using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Entities
{
    public class EducationOrganization : IEntityWithId
    {
        [Key]
        [Column("EducationOrganizationId")]
        public int Id { get; set; }
        [StringLength(60)]
        public string StateOrganizationId { get; set; }
        [StringLength(75)]
        public string NameOfInstitution { get; set; }
        [StringLength(255)]
        public string WebSite { get; set; }
        public virtual School School { get; set; }
    }
}

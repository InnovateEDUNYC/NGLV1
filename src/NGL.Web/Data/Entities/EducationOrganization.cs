using System.ComponentModel.DataAnnotations;

namespace NGL.Web.Data.Entities
{
    public class EducationOrganization
    {
        [Key]
        public int EducationOrganizationId { get; set; }
        public string StateOrganizationId { get; set; }
        public string NameOfInstitution { get; set; }
        public string ShortNameOfInstitution { get; set; }
        public string WebSite { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual School School { get; set; }
    }
}

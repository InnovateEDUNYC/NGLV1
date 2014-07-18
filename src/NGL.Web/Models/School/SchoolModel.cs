using System.ComponentModel.DataAnnotations;

namespace NGL.Web.Models.School
{
    public class SchoolModel
    {
        [StringLength(60)]
        public string StateOrganizationId { get; set; }

        [StringLength(75)]
        public string NameOfInstitution { get; set; }

        [StringLength(255)]
        public string WebSite { get; set; }
    }
}
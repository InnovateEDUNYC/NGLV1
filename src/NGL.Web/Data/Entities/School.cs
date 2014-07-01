using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NGL.Web.Data.Entities
{
    [Table("School", Schema = "edfi")]
    public class School
    {
        [Key, ForeignKey("EducationOrganization")]
        public int SchoolId { get; set; }
        public virtual EducationOrganization EducationOrganization { get; set; }
    }
}

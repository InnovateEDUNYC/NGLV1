using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NGL.Web.Models.Section;

namespace NGL.Web.Models.ClassPeriod
{
    public class ClassPeriodModel
    {
        public int SchoolId { get; set; }
        [StringLength(20)]
        public string ClassPeriodName { get; set; }

        public ICollection<SectionModel> Sections { get; set; }
    }
}
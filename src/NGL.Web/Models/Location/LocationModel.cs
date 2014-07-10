using System.Collections.Generic;
using NGL.Web.Models.School;
using NGL.Web.Models.Section;

namespace NGL.Web.Models.Location
{
    public class LocationModel
    {
        public string ClassroomIdentificationCode { get; set; }

        public SchoolModel School { get; set; }
        public ICollection<SectionModel> Sections { get; set; }
    }
}
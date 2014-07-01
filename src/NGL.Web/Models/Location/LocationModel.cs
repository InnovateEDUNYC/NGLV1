using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;
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
using System.Collections.Generic;

namespace NGL.Web.Models.Session
{
    public class SessionWithSectionsModel
    {
        public string Name { get; set; }
        public IList<CourseRowModel> CourseRows { get; set; }
    }

    public class CourseRowModel
    {
        public string Name { get; set; }

        public IList<SectionRowModel> SectionRows { get; set; }
    }

    public class SectionRowModel
    {
        public string UniqueSectionCode { get; set; }
        public string ClassPeriod { get; set; }
        public string Location { get; set; }
    }
}
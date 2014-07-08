using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;
using NGL.Web.Models.ClassPeriod;
using NGL.Web.Models.CourseOffering;
using NGL.Web.Models.Location;
using NGL.Web.Models.School;
using NGL.Web.Models.Session;
using NGL.Web.Models.StudentSectionAttendanceEvent;

namespace NGL.Web.Models.Section
{
    public class SectionModel
    {
        public string ClassPeriodName { get; set; }
        public string ClassroomIdentificationCode { get; set; }
        public string LocalCourseCode { get; set; }
        public int TermTypeId { get; set; }
        public short SchoolYear { get; set; }
        public string UniqueSectionCode { get; set; }
        public int SequenceOfCourse { get; set; }

        public virtual ClassPeriodModel ClassPeriod { get; set; }
        public virtual CourseOfferingModel CourseOffering { get; set; }
        public virtual LocationModel Location { get; set; }
        public virtual SchoolModel School { get; set; }
        public virtual CreateModel Session { get; set; }
        public virtual ICollection<StudentSectionAttendanceEventModel> StudentSectionAttendanceEvents { get; set; }
    }
}
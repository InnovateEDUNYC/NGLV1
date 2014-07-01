namespace NGL.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    
    public class AttendanceEventCategoryDescriptor
    {
        public int AttendanceEventCategoryDescriptorId { get; set; }
        public int AttendanceEventCategoryTypeId { get; set; }
    
        public virtual AttendanceEventCategoryType AttendanceEventCategoryType { get; set; }
        public virtual ICollection<StudentSchoolAttendanceEvent> StudentSchoolAttendanceEvents { get; set; }
        public virtual ICollection<StudentSectionAttendanceEvent> StudentSectionAttendanceEvents { get; set; }
    }
}

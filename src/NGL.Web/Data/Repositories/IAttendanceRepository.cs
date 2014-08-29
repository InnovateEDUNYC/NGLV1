using System;
using System.Collections.Generic;
using NGL.Web.Data.Entities;

namespace NGL.Web.Data.Repositories
{
    public interface IAttendanceRepository
    {
        List<StudentSectionAttendanceEvent> GetSectionAttendanceEventsFor(Section section, DateTime dateTime);
        void AddAttendanceEvents(IEnumerable<StudentSectionAttendanceEvent> studentSectionAttendanceEventList);
        void Delete(IEnumerable<StudentSectionAttendanceEvent> currentAttendanceEvent);
        List<StudentSectionAttendanceEvent> GetSectionAttendanceEventsFor(int studentUsi, short schoolYear);
        List<AttendanceFlag> GetAllFlags();
    }
}
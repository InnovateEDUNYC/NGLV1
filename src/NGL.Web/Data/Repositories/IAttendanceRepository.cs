using System;
using System.Collections.Generic;
using NGL.Web.Data.Entities;

namespace NGL.Web.Data.Repositories
{
    public interface IAttendanceRepository
    {
        List<StudentSectionAttendanceEvent> GetSectionAttendanceEventsFor(Section section, DateTime dateTime);
        void AddStudentSectionAttendanceEventList(IEnumerable<StudentSectionAttendanceEvent> studentSectionAttendanceEventList);
        void Delete(List<StudentSectionAttendanceEvent> currentAttendanceEvent);
    }
}
using System;
using System.Collections.Generic;
using NGL.Web.Data.Entities;

namespace NGL.Web.Service
{
    public interface IAttendanceService
    {
        void RecordAttendanceFor(Section section, DateTime date, IEnumerable<StudentSectionAttendanceEvent> newAttendanceEvents);
        void ClearAllFlags();
        void SetNewFlagCount(Student student, int newFlagCount);
    }
}

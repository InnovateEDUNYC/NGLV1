using System;
using System.Collections.Generic;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Repositories;

namespace NGL.Web.Service
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public void RecordAttendanceFor(Section section, DateTime date, IEnumerable<StudentSectionAttendanceEvent> studentSectionAttendanceEventList)
        {
            var currentAttendanceEvents = _attendanceRepository.GetSectionAttendanceEventsFor(section, date);

            if (!currentAttendanceEvents.IsNullOrEmpty())
                _attendanceRepository.Delete(currentAttendanceEvents);

            _attendanceRepository.AddStudentSectionAttendanceEventList(studentSectionAttendanceEventList);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void RecordAttendanceFor(Section section, DateTime date, IEnumerable<StudentSectionAttendanceEvent> newAttendanceEvents)
        {
            RemoveOldAttendanceEvents(section, date);
            AddNewAttendanceEvents(newAttendanceEvents);
        }

        public void SetNewFlagCount(Student student, int newFlagCount)
        {
            if (student.AttendanceFlags.IsNullOrEmpty())
                CreateNewAttendanceFlagEntryFor(student);

            student.AttendanceFlags.First().FlagCount = newFlagCount;
        }

        private static bool IsTardyOrUnexcused(int attendanceType)
        {
            return attendanceType == (int) AttendanceEventCategoryDescriptorEnum.Tardy ||
                   attendanceType == (int) AttendanceEventCategoryDescriptorEnum.UnexcusedAbsence;
        }

        private void RemoveOldAttendanceEvents(Section section, DateTime date)
        {
            var existingAttendanceEvents = _attendanceRepository.GetSectionAttendanceEventsFor(section, date);

            if (!existingAttendanceEvents.IsNullOrEmpty())
            {
                foreach (var attendanceEvent in existingAttendanceEvents.Where(attendanceEvent => IsTardyOrUnexcused
                    (attendanceEvent.AttendanceEventCategoryDescriptorId)))
                {
                    DecrementFlagCount(attendanceEvent.Student);
                }

                _attendanceRepository.Delete(existingAttendanceEvents);
            }
        }

        private void AddNewAttendanceEvents(IEnumerable<StudentSectionAttendanceEvent> newAttendanceEvents)
        {
            var studentSectionAttendanceEventList = newAttendanceEvents as IList<StudentSectionAttendanceEvent> ??
                                                    newAttendanceEvents.ToList();

            foreach (var attendanceEvent in studentSectionAttendanceEventList.Where(attendanceEvent => IsTardyOrUnexcused
                (attendanceEvent.AttendanceEventCategoryDescriptorId)))
            {
                IncrementFlagCount(attendanceEvent.Student);
            }

            _attendanceRepository.AddAttendanceEvents(studentSectionAttendanceEventList);
        }

        private static void DecrementFlagCount(Student student)
        {
            var flagCount = student.AttendanceFlags.First().FlagCount;

            if (flagCount > 0)
                student.AttendanceFlags.First().FlagCount--;
        }

        private static void IncrementFlagCount(Student student)
        {
            if (student.AttendanceFlags.IsNullOrEmpty())
                CreateNewAttendanceFlagEntryFor(student);

            var flagCount = student.AttendanceFlags.First().FlagCount;

            if (flagCount < 10)
                student.AttendanceFlags.First().FlagCount++;
        }

        private static void CreateNewAttendanceFlagEntryFor(Student student)
        {
            student.AttendanceFlags = new List<AttendanceFlag>
            {
                new AttendanceFlag
                {
                    FlagCount = 0,
                    StudentUSI = student.StudentUSI
                }
            };
        }

        public void ClearAllFlags()
        {
            var flags = _attendanceRepository.GetAllFlags();
            foreach (var flag in flags)
            {
                flag.FlagCount = 0;
            }
        }
    }
}

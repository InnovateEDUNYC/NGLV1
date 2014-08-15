using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Attendance
{
    public class SectionToTakeAttendanceModelMapper
    {
        public TakeAttendanceModel Build(Data.Entities.Section section, List<Data.Entities.StudentSectionAttendanceEvent> existingStudentSectionAttendanceEvents, DateTime date)
        {
            var target = new TakeAttendanceModel();

            target.SectionId = section.SectionIdentity;
            target.Section = section.UniqueSectionCode + " (" + section.LocalCourseCode + ", " + section.ClassPeriodName + ")";
            target.SessionId = section.Session.SessionIdentity;
            target.Session = section.Session.SessionName;

            target.StudentRows = section.StudentSectionAssociations.Select(ssa => ssa.Student)
                .Select(s => new StudentAttendanceRowModel
                {
                    StudentUsi = s.StudentUSI,
                    StudentName = s.FirstName + " " + s.LastSurname,
                    AttendanceType = AttendanceEventCategoryDescriptorEnum.InAttendance
                }).ToList();

            if (!existingStudentSectionAttendanceEvents.IsNullOrEmpty())
            {
                foreach (var ssae in existingStudentSectionAttendanceEvents)
                {
                    target.StudentRows.First(sr => sr.StudentUsi == ssae.StudentUSI).AttendanceType =
                        (AttendanceEventCategoryDescriptorEnum) ssae.AttendanceEventCategoryDescriptorId;
                }
            }

            return target;
        }
    }
}
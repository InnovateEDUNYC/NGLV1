using System;
using System.Linq;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;
using NGL.Web.Infrastructure.Azure;

namespace NGL.Web.Models.Attendance
{
    public class SectionToTakeAttendanceModelMapper
    {
        private readonly ProfilePhotoUrlFetcher _profilePhotoUrlFetcher;

        public SectionToTakeAttendanceModelMapper(ProfilePhotoUrlFetcher profilePhotoUrlFetcher)
        {
            _profilePhotoUrlFetcher = profilePhotoUrlFetcher;
        }

        public TakeAttendanceModel Build(Data.Entities.Section section, DateTime date)
        {
            var target = new TakeAttendanceModel();

            target.SectionId = section.SectionIdentity;
            target.Section = section.UniqueSectionCode + " (" + section.LocalCourseCode + ", " + section.ClassPeriodName + ")";
            target.SessionId = section.Session.SessionIdentity;
            target.Session = section.Session.SessionName;
            target.Date = date.ToShortDateString();

            target.StudentRows = section.StudentSectionAssociations.Select(ssa => ssa.Student)
                .Select(s => new StudentAttendanceRowModel
                {
                    StudentUsi = s.StudentUSI,
                    StudentName = s.FirstName + " " + s.LastSurname,
                    ProfileThumbnailUrl = _profilePhotoUrlFetcher.GetProfilePhotoThumnailUrlOrDefault(s.StudentUSI),
                    AttendanceType = AttendanceEventCategoryDescriptorEnum.InAttendance
                }).ToList();

            var existingStudentSectionAttendanceEvents = section.StudentSectionAttendanceEvents.Where(ssae => ssae.EventDate == date).ToList();

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
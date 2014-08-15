using System.Linq;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Attendance
{
    public class SectionToTakeAttendanceModelMapper: MapperBase<Data.Entities.Section, TakeAttendanceModel>
    {
        public override void Map(Data.Entities.Section source, TakeAttendanceModel target)
        {
            target.SectionId = source.SectionIdentity;
            target.Section = source.UniqueSectionCode + " (" + source.LocalCourseCode + ", " + source.ClassPeriodName + ")";
            target.SessionId = source.Session.SessionIdentity;
            target.Session = source.Session.SessionName;

            target.StudentRows = source.StudentSectionAssociations.Select(ssa => ssa.Student)
                .Select(s => new StudentAttendanceRowModel
                {
                    StudentUsi = s.StudentUSI,
                    StudentName = s.FirstName + " " + s.LastSurname,
                    AttendanceType = AttendanceEventCategoryDescriptorEnum.InAttendance
                }).ToList();
        }
    }
}
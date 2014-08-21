using System;
using System.Collections.Generic;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Repositories
{
    public class AttendanceRepository : RepositoryBase, IAttendanceRepository
    {
        public AttendanceRepository(INglDbContext dbContext) : base(dbContext) { }

        public List<StudentSectionAttendanceEvent> GetSectionAttendanceEventsFor(Section section, DateTime dateTime)
        {
            return DbContext.Set<StudentSectionAttendanceEvent>()
                .Where(ssae =>
                    ssae.EventDate == dateTime
                    && ssae.SchoolId == section.SchoolId
                    && ssae.ClassPeriodName == section.ClassPeriodName
                    && ssae.ClassroomIdentificationCode == section.ClassroomIdentificationCode
                    && ssae.LocalCourseCode == section.LocalCourseCode
                    && ssae.TermTypeId == section.TermTypeId
                    && ssae.SchoolYear == section.SchoolYear
                ).ToList();

        }

        public List<StudentSectionAttendanceEvent> GetSectionAttendanceEventsFor(int studentUsi, short schoolYear)
        {
            return DbContext.Set<StudentSectionAttendanceEvent>()
                .Where(ssae => ssae.StudentUSI == studentUsi && ssae.SchoolYear == schoolYear).ToList();
        }

        public void AddStudentSectionAttendanceEventList(IEnumerable<StudentSectionAttendanceEvent> studentSectionAttendanceEventList)
        {
            foreach (var ssae in studentSectionAttendanceEventList)
            {
                DbContext.Set<StudentSectionAttendanceEvent>().Add(ssae);
            }
        }

        public void Delete(IEnumerable<StudentSectionAttendanceEvent> studentSectionAttendanceEvents)
        {
            foreach (var ssae in studentSectionAttendanceEvents)
                DbContext.Set<StudentSectionAttendanceEvent>().Remove(ssae);
        }
    }
}
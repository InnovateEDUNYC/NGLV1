using System;
using System.Data.Entity;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Dates;

namespace NGL.Web.Data.Repositories
{
    public class SectionRepository: RepositoryBase, ISectionRepository
    {
        public SectionRepository(INglDbContext dbContext) : base(dbContext) { }
        public Section GetWithStudentAttendanceForDate(int sectionIdentity, DateTime date)
        {
            var section = DbContext.Set<Section>()
                .Where(s => s.SectionIdentity == sectionIdentity)
                .Include(s => s.Session)
                .Include(s => s.StudentSectionAssociations.Select(ssa => ssa.Student))
                .Include(s => s.StudentSectionAttendanceEvents)
                .ToList().FirstOrDefault();

            var studentSectionAssociationsOnDate = section.StudentSectionAssociations
                .Where(ssa => new DateRange(ssa.BeginDate, ssa.EndDate.Value).Includes(date)).ToList();

            section.StudentSectionAssociations = studentSectionAssociationsOnDate;

            var studentSectionAttendanceEventsOnDate = section.StudentSectionAttendanceEvents
                .Where(ssae => ssae.EventDate == date).ToList();

            section.StudentSectionAttendanceEvents = studentSectionAttendanceEventsOnDate;

            return section;
        }
    }
}
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
        public Section GetWithStudentAssociationsForDate(int sectionIdentity, DateTime date)
        {
            var sections = DbContext.Set<Section>()
                .Where(s => s.SectionIdentity == sectionIdentity)
                .Include(s => s.Session)
                .Include(s => s.StudentSectionAssociations.Select(ssa => ssa.Student))
                .ToList();

            var section = sections.FirstOrDefault();
            var studentSectionAssociationsOnDate = section.StudentSectionAssociations
                .Where(ssa => new DateRange(ssa.BeginDate, ssa.EndDate.Value).Includes(date)).ToList();

            section.StudentSectionAssociations = studentSectionAssociationsOnDate;

            return section;
        }
    }
}
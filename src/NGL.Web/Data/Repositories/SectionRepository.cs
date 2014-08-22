using System.Data.Entity;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Repositories
{
    public class SectionRepository: RepositoryBase, ISectionRepository
    {
        public SectionRepository(INglDbContext dbContext) : base(dbContext) { }

        public Section GetWithStudentAttendance(int sectionIdentity)
        {
            var section = DbContext.Set<Section>()
                .Where(s => s.SectionIdentity == sectionIdentity)
                .Include(s => s.Session)
                .Include(s => s.StudentSectionAssociations.Select(ssa => ssa.Student))
                .Include(s => s.StudentSectionAttendanceEvents)
                .ToList().FirstOrDefault();

            return section;
        }

        public Section GetWithStudentsAndSession(int sectionIdentity)
        {
            return DbContext.Set<Section>()
                .Where(s => s.SectionIdentity == sectionIdentity)
                .Include(s => s.StudentSectionAssociations.Select(ssa => ssa.Student))
                .Include(s => s.Session).FirstOrDefault();
        }
    }
}
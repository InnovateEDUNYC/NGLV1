using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Exceptions;

namespace NGL.Web.Data.Repositories
{
    public class SectionRepository: RepositoryBase, ISectionRepository
    {
        private const int ConstraintViolation = 547;

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

        public Section GetWithAttendanceFlags(int? sectionIdentity)
        {
            var section = DbContext.Set<Section>()
                .Where(s => s.SectionIdentity == sectionIdentity)
                .Include(s => s.StudentSectionAssociations)
                .Include(s => s.StudentSectionAssociations.Select(ssa => ssa.Student))
                .Include(s => s.StudentSectionAssociations.Select(ssa => ssa.Student.AttendanceFlags))
                .ToList().FirstOrDefault();

            return section;
        }

        public void Remove(int sectionIdentity)
        {
            var existing = DbContext.Set<Section>().First(s => s.SectionIdentity == sectionIdentity);

            try
            {
                DbContext.Set<Section>().Remove(existing);
                Save();
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException == null || e.InnerException.InnerException == null) throw;
                var innerException = e.InnerException.InnerException as SqlException;
                if (innerException != null && innerException.Number == ConstraintViolation)
                {
                    throw new NglException();
                }
                throw;
            }
        }

        public bool HasDependencies(int sectionIdentity)
        {
            var section = GetWithDependencies(sectionIdentity);

            return section.StudentSectionAssociations.Any() ||
                   section.StudentSectionAttendanceEvents.Any() ||
                   section.AssessmentSections.Any() ||

                   section.GradebookEntries.Any() ||
                   section.SectionAttendanceTakenEvents.Any() ||
                   section.SectionCharacteristics.Any() ||
                   section.SectionPrograms.Any() ||
                   section.StaffSectionAssociations.Any() ||
                   section.StudentCohortAssociationSections.Any();
        }

        private Section GetWithDependencies(int sectionIdentity)
        {
            var section = DbContext.Set<Section>()
                .Where(s => s.SectionIdentity == sectionIdentity)
                
                .Include(s => s.StudentSectionAssociations)
                .Include(s => s.StudentSectionAttendanceEvents)
                .Include(s => s.AssessmentSections)

                .Include(s => s.GradebookEntries)
                .Include(s => s.SectionAttendanceTakenEvents)
                .Include(s => s.SectionCharacteristics)
                .Include(s => s.SectionPrograms)
                .Include(s => s.StaffSectionAssociations)
                .Include(s => s.StudentCohortAssociationSections)

                .ToList().FirstOrDefault();

            return section;
        }
    }
}
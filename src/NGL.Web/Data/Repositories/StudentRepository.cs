using System.Data.Entity;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Repositories
{
    public class StudentRepository : RepositoryBase, IStudentRepository 
    {
        public StudentRepository(INglDbContext dbContext) : base(dbContext) { }

        public Student GetByUSI(int studentUsi)
        {
            var student = DbContext.Set<Student>()
                .Where(s => s.StudentUSI == studentUsi)
                .Include(s => s.StudentAddresses)
                .Include(s => s.StudentRaces)
                .Include(s => s.StudentLanguages)
                .Include(s => s.StudentLanguages.Select(l => l.StudentLanguageUses))
                .Include(s => s.StudentParentAssociations.Select(p => p.Parent))
                .Include(s => s.StudentParentAssociations.Select(p => p.Parent.ParentAddresses))
                .Include(s => s.StudentParentAssociations.Select(p => p.Parent.ParentTelephones))
                .Include(s => s.StudentParentAssociations.Select(p => p.Parent.ParentElectronicMails))
                .Include(s => s.StudentAcademicDetails)
                .Include(s => s.StudentProgramStatus)
                .ToList().SingleOrDefault();

            return student;
        }
    }
}
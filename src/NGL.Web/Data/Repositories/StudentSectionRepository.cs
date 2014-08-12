using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Repositories
{
    public class StudentSectionRepository : RepositoryBase, IStudentSectionRepository
    {
        public StudentSectionRepository(INglDbContext dbContext) : base(dbContext) { }
        public void Delete(StudentSectionAssociation studentSectionAssociation)
        {
                DbContext.Set<StudentSectionAssociation>().Remove(studentSectionAssociation);
                DbContext.Save();
        }

        public StudentSectionAssociation GetByIdentity(int studentSectionIdentity)
        {
            return DbContext.Set<StudentSectionAssociation>()
                .SingleOrDefault(ssa => ssa.StudentSectionAssociationIdentity == studentSectionIdentity);
        }
    }
}
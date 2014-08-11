using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Repositories
{
    public class StudentSectionRepository : RepositoryBase, IStudentSectionRepository
    {
        public StudentSectionRepository(INglDbContext dbContext) : base(dbContext) { }
        public void DeleteByIdentity(int studentSectionIdentity)
        {
            var existing = DbContext.Set<StudentSectionAssociation>().SingleOrDefault(ssa => ssa.StudentSectionAssociationIdentity == studentSectionIdentity);

            if (existing != null)
            {
                DbContext.Set<StudentSectionAssociation>().Remove(existing);
                DbContext.Save();
            }
        }
    }
}
using System.Data.Entity;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Repositories
{
    public class ParentRepository : RepositoryBase, IParentRepository
    {
        public ParentRepository(INglDbContext dbContext) : base(dbContext) { }

        public Parent GetByUSI(int parentUsi)
        {
            return DbContext.Set<Parent>()
                .Where(p => p.ParentUSI == parentUsi)
                .Include(p => p.ParentTelephones)
                .Include(p => p.ParentElectronicMails)
                .Include(p => p.StudentParentAssociations)
                .ToList().First();
        }
    }
}
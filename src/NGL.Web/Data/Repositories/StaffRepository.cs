using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Repositories
{
    public class StaffRepository : RepositoryBase, IStaffRepository
    {
        public StaffRepository(INglDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Staff> GetStaffWithUsers()
        {
            return DbContext.Set<Staff>().Include(s => s.Users.Select(u => u.AspNetRoles));
        }

        public Staff GetStaffByStaffUSI(int staffUSI)
        {
            return DbContext.Set<Staff>().SingleOrDefault(s => s.StaffUSI == staffUSI);
        }
    }
}
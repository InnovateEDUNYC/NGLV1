using System.Collections.Generic;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Repositories
{
    public interface IStaffRepository : IRepositoryBase
    {
        IEnumerable<Staff> GetStaffWithUsers();
        Staff GetStaffByStaffUSI(int staffUSI);
    }
}
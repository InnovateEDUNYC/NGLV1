using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Queries
{
    public class StaffUserQuery : IQuery<Staff>
    {
        public IQueryable<Staff> ApplyPredicate(IQueryable<Staff> inputSet)
        {
            return inputSet;
        }
    }
}
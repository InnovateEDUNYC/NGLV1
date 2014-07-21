using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Queries
{
    public class UserRolesQuery : IQuery<AspNetUser>
    {
        public IQueryable<AspNetUser> ApplyPredicate(IQueryable<AspNetUser> inputSet)
        {
            return inputSet;
        }
    }
}
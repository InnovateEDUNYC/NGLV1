using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using NGL.Web.Data.Entities;

namespace NGL.Web.Data
{
    public class NglDbContext : IdentityDbContext<ApplicationUser>, INglDbContext
    {
        public NglDbContext()
            : base("DefaultConnection")
        {
        }

        public void Save()
        {
            SaveChanges();
        }

        IDbSet<TEntity> INglDbContext.Set<TEntity>()
        {
            return Set<TEntity>();
        }
    }
}
using System.Data.Entity;

namespace NGL.Web.Data.Entities
{
    public partial class NglDbContext : INglDbContext
    {
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

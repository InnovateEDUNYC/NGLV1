using System;
using System.Data.Entity;
using System.Diagnostics;

namespace NGL.Web.Data.Entities
{
    public partial class NglDbContext : INglDbContext
    {
        public void Save()
        {
            try
            {
                SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                throw;
            }
        }
    
        IDbSet<TEntity> INglDbContext.Set<TEntity>()
        {
            return Set<TEntity>();
        }
    }
}

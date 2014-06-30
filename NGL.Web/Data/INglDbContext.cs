using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data
{
    public interface INglDbContext: IUnitOfWork, IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
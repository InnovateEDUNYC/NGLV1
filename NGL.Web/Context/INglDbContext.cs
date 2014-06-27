using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using NGL.Web.Context.Infrastructure;

namespace NGL.Web.Context
{
    public interface INglDbContext: IUnitOfWork, IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
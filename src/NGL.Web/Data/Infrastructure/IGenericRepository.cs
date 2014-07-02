using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NGL.Web.Data.Repositories;

namespace NGL.Web.Data.Infrastructure
{
    public interface IGenericRepository : IRepositoryBase
    {
        void Attach<TEntity>(TEntity entity) where TEntity : class;
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;
        TEntity Get<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] associations) where TEntity : class;
        TEntity Get<TEntity>(IQuery<TEntity> query, params Expression<Func<TEntity, object>>[] associations) where TEntity : class;
        TOutput Get<TEntity, TOutput>(IQuery<TEntity, TOutput> query)
            where TEntity : class
            where TOutput : class;

        TEntity Get<TEntity>(int id, params Expression<Func<TEntity, object>>[] associations) where TEntity : class, IEntityWithId;
        IEnumerable<TEntity> Get<TEntity>(IEnumerable<int> ids) where TEntity : class, IEntityWithId;

        IQueryable<TEntity> Query<TEntity>() where TEntity : class;
        IQueryable<TEntity> Query<TEntity>(IQuery<TEntity> query, params Expression<Func<TEntity, object>>[] associations)
            where TEntity : class;
        IQueryable<TOutput> Query<TEntity, TOutput>(IQuery<TEntity, TOutput> query) where TEntity : class;

        bool Any<TEntity>(IQuery<TEntity> query) where TEntity : class;
        bool Any<TEntity, TOutputEntity>(IQuery<TEntity, TOutputEntity> query)
            where TEntity : class
            where TOutputEntity : class;

        void Add<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(int id) where TEntity : class, IEntityWithId;
    } 
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NGL.Web.Data.Infrastructure
{
    public interface IGenericRepository
    {
        void Attach<TEntity>(TEntity entity) where TEntity : class, IEntity;
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class, IEntity;
        TEntity Get<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] associations) where TEntity : class, IEntity;
        TEntity Get<TEntity>(IQuery<TEntity> query, params Expression<Func<TEntity, object>>[] associations) where TEntity : class, IEntity;
        TOutput Get<TEntity, TOutput>(IQuery<TEntity, TOutput> query)
            where TEntity : class, IEntity
            where TOutput : class, IEntity;

        TEntity Get<TEntity>(int id, params Expression<Func<TEntity, object>>[] associations) where TEntity : class, IEntityWithId;
        IEnumerable<TEntity> Get<TEntity>(IEnumerable<int> ids) where TEntity : class, IEntityWithId;

        IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity;
        IQueryable<TEntity> Query<TEntity>(IQuery<TEntity> query, params Expression<Func<TEntity, object>>[] associations)
            where TEntity : class, IEntity;
        IQueryable<TOutput> Query<TEntity, TOutput>(IQuery<TEntity, TOutput> query) where TEntity : class, IEntity;

        bool Any<TEntity>(IQuery<TEntity> query) where TEntity : class, IEntity;
        bool Any<TEntity, TOutputEntity>(IQuery<TEntity, TOutputEntity> query)
            where TEntity : class, IEntity
            where TOutputEntity : class, IEntity;

        void Add<TEntity>(TEntity entity) where TEntity : class, IEntity;
        void Delete<TEntity>(int id) where TEntity : class, IEntityWithId;
        void Save();
    } 
}
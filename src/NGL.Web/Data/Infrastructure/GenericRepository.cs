using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace NGL.Web.Data.Infrastructure
{
    public class GenericRepository : RepositoryBase, IGenericRepository
    {
        public GenericRepository(INglDbContext dbContext) : base(dbContext)
        {
        }

        public virtual TEntity Get<TEntity>(IQuery<TEntity> query, params Expression<Func<TEntity, object>>[] associations)
            where TEntity : class
        {
            return Query(query, associations).SingleOrDefault();
        }

        public IEnumerable<TEntity> GetAll<TEntity>(IQuery<TEntity> query) 
            where TEntity : class
        {
            return Query(query);
        }

        public TOutput Get<TEntity, TOutput>(IQuery<TEntity, TOutput> query)
            where TEntity : class
            where TOutput : class
        {
            return Query(query).SingleOrDefault();
        }

        public virtual TEntity Get<TEntity>(int id, params Expression<Func<TEntity, object>>[] associations) where TEntity : class, IEntityWithId
        {
            if (associations.Any() == false)
                return DbContext.Set<TEntity>().Find(id);

            //http://blogs.msdn.com/b/adonet/archive/2011/01/31/using-dbcontext-in-ef-feature-ctp5-part-6-loading-related-entities.aspx

            var query = associations.Aggregate(DbContext.Set<TEntity>().AsQueryable(), (current, path) => current.Include(path));
            return query.SingleOrDefault(i => i.Id == id);
        }

        public IEnumerable<TEntity> Get<TEntity>(IEnumerable<int> ids) where TEntity : class, IEntityWithId
        {
            // Note: At some stage this may need to be made a bit smarter so it could deal with large list of ids
            return DbContext.Set<TEntity>().Where(e => ids.Contains(e.Id));
        }

        public IQueryable<TEntity> Query<TEntity>(IQuery<TEntity> query, params Expression<Func<TEntity, object>>[] associations) where TEntity : class
        {
            var queryWithAssociations = associations.Aggregate(DbContext.Set<TEntity>().AsQueryable(), (current, path) => current.Include(path));
            return query.ApplyPredicate(queryWithAssociations);
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return DbContext.Set<TEntity>();
        }

        public IQueryable<TOutput> Query<TEntity, TOutput>(IQuery<TEntity, TOutput> query) where TEntity : class
        {
            return query.ApplyPredicate(DbContext.Set<TEntity>());
        }

        public bool Any<TEntity>(IQuery<TEntity> query) where TEntity : class
        {
            return query.ApplyPredicate(DbContext.Set<TEntity>()).Any();
        }

        public bool Any<TEntity, TOutputEntity>(IQuery<TEntity, TOutputEntity> query)
            where TEntity : class
            where TOutputEntity : class
        {
            return query.ApplyPredicate(DbContext.Set<TEntity>()).Any();
        }

        public virtual void Add<TEntity>(TEntity entity) where TEntity : class
        {
            DbContext.Set<TEntity>().Add(entity);
        }

        public void Attach<TEntity>(TEntity entity) where TEntity : class
        {
            DbContext.Entry(entity).State = EntityState.Detached;
            DbContext.Set<TEntity>().Attach(entity);
        }

        public virtual IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            // I do not want the result of GetAll to be IQueriable<TEntity> otherwise dev may just start using GetAll from everywhere instead of implementing queries properly
            return DbContext.Set<TEntity>().ToList();
        }

        public virtual TEntity Get<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] associations)
            where TEntity : class
        {
            var query = associations.Aggregate(DbContext.Set<TEntity>().AsQueryable(), (current, path) => current.Include(path));
            return query.SingleOrDefault(predicate);
        }

        public virtual void Delete<TEntity>(int id) where TEntity : class, IEntityWithId
        {
            var existing = DbContext.Set<TEntity>().Find(id);
            DbContext.Set<TEntity>().Remove(existing);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            DbContext.Set<TEntity>().Remove(entity);
        }
    }
}
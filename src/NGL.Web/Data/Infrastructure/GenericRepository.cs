using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace NGL.Web.Data.Infrastructure
{
    public class GenericRepository : IGenericRepository
    {
        private readonly INglDbContext _context;

        public GenericRepository(INglDbContext context)
        {
            _context = context;
        }

        public virtual TEntity Get<TEntity>(IQuery<TEntity> query, params Expression<Func<TEntity, object>>[] associations)
            where TEntity : class, IEntity
        {
            return Query(query, associations).SingleOrDefault();
        }

        public TOutput Get<TEntity, TOutput>(IQuery<TEntity, TOutput> query)
            where TEntity : class, IEntity
            where TOutput : class, IEntity
        {
            return Query(query).SingleOrDefault();
        }

        public virtual TEntity Get<TEntity>(int id, params Expression<Func<TEntity, object>>[] associations) where TEntity : class, IEntityWithId
        {
            if (associations.Any() == false)
                return _context.Set<TEntity>().Find(id);

            //http://blogs.msdn.com/b/adonet/archive/2011/01/31/using-dbcontext-in-ef-feature-ctp5-part-6-loading-related-entities.aspx

            var query = associations.Aggregate(_context.Set<TEntity>().AsQueryable(), (current, path) => current.Include(path));
            return query.SingleOrDefault(i => i.Id == id);
        }

        public IEnumerable<TEntity> Get<TEntity>(IEnumerable<int> ids) where TEntity : class, IEntityWithId
        {
            // Note: At some stage this may need to be made a bit smarter so it could deal with large list of ids
            return _context.Set<TEntity>().Where(e => ids.Contains(e.Id));
        }

        public IQueryable<TEntity> Query<TEntity>(IQuery<TEntity> query, params Expression<Func<TEntity, object>>[] associations) where TEntity : class, IEntity
        {
            var queryWithAssociations = associations.Aggregate(_context.Set<TEntity>().AsQueryable(), (current, path) => current.Include(path));
            return query.ApplyPredicate(queryWithAssociations);
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity
        {
            return _context.Set<TEntity>();
        }

        public IQueryable<TOutput> Query<TEntity, TOutput>(IQuery<TEntity, TOutput> query) where TEntity : class, IEntity
        {
            return query.ApplyPredicate(_context.Set<TEntity>());
        }

        public bool Any<TEntity>(IQuery<TEntity> query) where TEntity : class, IEntity
        {
            return query.ApplyPredicate(_context.Set<TEntity>()).Any();
        }

        public bool Any<TEntity, TOutputEntity>(IQuery<TEntity, TOutputEntity> query)
            where TEntity : class, IEntity
            where TOutputEntity : class, IEntity
        {
            return query.ApplyPredicate(_context.Set<TEntity>()).Any();
        }

        public virtual void Add<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Attach<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            _context.Entry(entity).State = EntityState.Detached;
            _context.Set<TEntity>().Attach(entity);
        }

        public virtual IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class, IEntity
        {
            // I do not want the result of GetAll to be IQueriable<TEntity> otherwise dev may just start using GetAll from everywhere instead of implementing queries properly
            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity Get<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] associations)
            where TEntity : class, IEntity
        {
            var query = associations.Aggregate(_context.Set<TEntity>().AsQueryable(), (current, path) => current.Include(path));
            return query.SingleOrDefault(predicate);
        }

        public virtual void Delete<TEntity>(int id) where TEntity : class, IEntityWithId
        {
            var existing = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Remove(existing);
        }

        public void Save()
        {
            _context.Save();
        }
    }
}
using System;
using System.Linq.Expressions;

namespace NGL.Web.Data.Infrastructure
{
    public abstract class Specification<T>
    {
        private readonly Expression<Func<T, bool>> _specExpression;
        private readonly Func<T, bool> _specFunction;

        protected Specification(Expression<Func<T, bool>> spec)
        {
            _specExpression = spec;
            _specFunction = spec.Compile();
        }

        public virtual Expression<Func<T, bool>> IsSatisfied()
        {
            return _specExpression;
        }

        public virtual bool IsSatisfiedBy(T entity)
        {
            return _specFunction(entity);
        }
    }
}
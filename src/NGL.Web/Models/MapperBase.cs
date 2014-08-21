using System;

namespace NGL.Web.Models
{
    public abstract class MapperBase<TSource, TTarget> : IMapper<TSource, TTarget> 
        where TSource : class
        where TTarget : class, new()
    {
        public abstract void Map(TSource source, TTarget target);

        public void Map(TSource source, TTarget target, Action<TTarget> injectProperties)
        {
            Map(source, target);
            injectProperties(target);
        }

        public TTarget Build(TSource source, Action<TTarget> injectProperties)
        {
            var target = Build(source);
            injectProperties(target);
            return target;
        }

        public virtual TTarget Build(TSource source)
        {
            var target = new TTarget();
            Map(source, target);
            return target;
        }
    }
}
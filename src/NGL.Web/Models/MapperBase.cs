namespace NGL.Web.Models
{
    public abstract class MapperBase<TSource, TTarget> : IMapper<TSource, TTarget> 
        where TSource : class, new()
        where TTarget : class, new()
    {
        public abstract void Map(TSource source, TTarget target);

        public virtual TTarget Build(TSource source)
        {
            var target = new TTarget();
            Map(source, target);
            return target;
        }
    }
}
namespace NGL.Web.Models
{
    public interface IMapper<in TSource, TTarget>
        where TSource: class, new()
        where TTarget: class, new()
    {
        void Map(TSource source, TTarget target);
        TTarget Build(TSource source);
    }
}

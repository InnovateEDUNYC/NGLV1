namespace NGL.Web.Models
{
    public interface IMapper<in TSource, in TTarget>
        where TSource: class
        where TTarget: class
    {
        void Map(TSource source, TTarget target);
    }
}

namespace NGL.Web.Models
{
    interface IMapper<in TSource, in TTarget>
        where TSource: class
        where TTarget: class
    {
        void Map(TSource source, TTarget target);
    }
}

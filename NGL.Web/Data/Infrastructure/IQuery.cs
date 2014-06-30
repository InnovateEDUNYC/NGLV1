using System.Linq;

namespace NGL.Web.Data.Infrastructure
{
    public interface IQuery<T>
    {
        IQueryable<T> ApplyPredicate(IQueryable<T> inputSet);
    }

    public interface IQuery<in TInput, out TOutput>
        where TInput : IEntity
    {
        IQueryable<TOutput> ApplyPredicate(IQueryable<TInput> inputSet);
    }
}
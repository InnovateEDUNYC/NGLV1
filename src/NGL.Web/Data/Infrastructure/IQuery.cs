using System.Linq;

namespace NGL.Web.Data.Infrastructure
{
    public interface IQuery<T>
    {
        IQueryable<T> ApplyPredicate(IQueryable<T> inputSet);
    }

    public interface IQuery<in TInput, out TOutput>
        where TInput : class 
    {
        IQueryable<TOutput> ApplyPredicate(IQueryable<TInput> inputSet);
    }
}
using System;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models
{
    public interface IMapper<in TSource, TTarget>
        where TSource: class, new()
        where TTarget: class, new()
    {
        void Map(TSource source, TTarget target, Action<TTarget> injectProperties);
        void Map(TSource source, TTarget target);
        TTarget Build(TSource source, Action<TTarget> injectProperties);
        TTarget Build(TSource source);
    }
}

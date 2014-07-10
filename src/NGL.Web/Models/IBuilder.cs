using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGL.Web.Models
{
    public interface IBuilder<in TSource, out TTarget>
        where TSource : class
        where TTarget : class
    {
        TTarget Build(TSource source);
    }
}
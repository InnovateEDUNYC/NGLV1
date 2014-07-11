using System;
using System.Linq.Expressions;

namespace NGL.Web.Infrastructure
{
    public static class From<TClass> where TClass : class 
    {
        public static string GetNameFor(Expression<Func<TClass, object>> exp)
        {
            var body = exp.Body as MemberExpression;

            if (body == null)
            {
                var ubody = (UnaryExpression)exp.Body;
                body = ubody.Operand as MemberExpression;
            }

            return body.Member.Name;
        }
    }

    public static class PropertyNameExtensions
    {
        public static string GetNameFor<TClass>(this TClass instance, Expression<Func<TClass, object>> exp) 
            where TClass : class
        {
            return From<TClass>.GetNameFor(exp);
        }
    }
}
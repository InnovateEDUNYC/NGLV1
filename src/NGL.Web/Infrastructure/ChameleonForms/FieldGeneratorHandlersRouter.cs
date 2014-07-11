using System.Collections.Generic;
using ChameleonForms.FieldGenerators;
using ChameleonForms.FieldGenerators.Handlers;
using System.Linq;

namespace NGL.Web.Infrastructure.ChameleonForms
{
    internal static class FieldGeneratorHandlersRouter<TModel, T>
    {
        private static IEnumerable<FieldGeneratorHandler<TModel, T>> GetHandlers(IFieldGenerator<TModel, T> g)
        {
            yield return new EnumListHandler<TModel, T>(g);
            yield return new PasswordHandler<TModel, T>(g);
            yield return new TextAreaHandler<TModel, T>(g);
            yield return new BooleanHandler<TModel, T>(g);
            yield return new FileHandler<TModel, T>(g);
            yield return new ListHandler<TModel, T>(g);
            yield return new NglDateTimeHandler<TModel, T>(g);
            yield return new DefaultHandler<TModel, T>(g);
        }

        public static IFieldGeneratorHandler<TModel, T> GetHandler(IFieldGenerator<TModel, T> fieldGenerator)
        {
            return GetHandlers(fieldGenerator)
                .First(h => h.CanHandle());
        }
    }
}

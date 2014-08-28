using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Castle.Core.Internal;
using NGL.Web.Models.Shared;

namespace NGL.Web.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        public static IList<NglErrorModel> GetNglErrors(this ModelStateDictionary modelState)
        {
            var errorAndFields = modelState.Where(k => !CollectionExtensions.IsNullOrEmpty(k.Value.Errors));
            return errorAndFields.Select(eaf => new NglErrorModel(eaf.Key, eaf.Value.Errors.First().ErrorMessage)).ToList();
        }
    }
}
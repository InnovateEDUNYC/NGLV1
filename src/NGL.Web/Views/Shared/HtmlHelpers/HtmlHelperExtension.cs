using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Humanizer;
using NGL.Web.Data.Entities;

namespace NGL.Web.Views.Shared.HtmlHelpers
{
    public static class HtmlHelperExtension
    {
        public static IEnumerable<SelectListItem> GetHumanizedListItems<TEnum>(this TEnum @enum)
        {
            return
                Enum.GetNames(@enum.GetType())
                    .Select( x => new SelectListItem {
                        Text = ((Enum) (Enum.Parse(@enum.GetType(), x))).Humanize(), 
                        Value = x
                    });
        }
    }
}
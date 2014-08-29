using System;
using NGL.Web.Data.Entities;

namespace NGL.Web.Data.Filters
{
    public interface ISessionFilter
    {
        Session FindSession(DateTime dateToCheck);
    }
}

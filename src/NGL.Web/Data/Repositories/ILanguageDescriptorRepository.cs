using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Repositories
{
    public interface ILanguageDescriptorRepository : IRepositoryBase
    {
        LanguageDescriptor GetLanguageDescriptor(int languageTypeId);
    }
}
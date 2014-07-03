using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Repositories
{
    public class LanguageDescriptorRepository : RepositoryBase, ILanguageDescriptorRepository
    {
        public LanguageDescriptorRepository(INglDbContext dbContext) : base(dbContext)
        {
        }

        public LanguageDescriptor GetLanguageDescriptor(int languageTypeId)
        {
//            return DbContext.Set<School>().Include(s => s.EducationOrganization).FirstOrDefault();
            IDbSet<LanguageDescriptor> dbSet = DbContext.Set<LanguageDescriptor>();
            IQueryable<LanguageDescriptor> languageDescriptors = dbSet.Where(l => l.LanguageTypeId == languageTypeId);
            return languageDescriptors.FirstOrDefault();
        }
    }
}
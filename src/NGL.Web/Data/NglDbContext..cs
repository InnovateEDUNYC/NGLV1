﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using NGL.Web.Data.Entities;

namespace NGL.Web.Data
{
    public class NglDbContext : IdentityDbContext<ApplicationUser>, INglDbContext
    {
        public NglDbContext()
            : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }
    
        public void Save()
        {
            SaveChanges();
        }
    
        IDbSet<TEntity> INglDbContext.Set<TEntity>()
        {
            return Set<TEntity>();
        }
    
        public virtual DbSet<EducationOrganization> EducationOrganizations { get; set; }
        public virtual DbSet<School> Schools { get; set; }
    }
}

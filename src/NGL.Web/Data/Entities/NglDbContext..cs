using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NGL.Web.Data.Entities
{
    public partial class NglDbContext : INglDbContext
    {
        public void Save()
        {
            SaveChanges();
        }
    
        IDbSet<TEntity> INglDbContext.Set<TEntity>()
        {
            return Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.HasDefaultSchema("edfi");

            //modelBuilder
            //    .Entity<ApplicationUser>()
            //    .ToTable("AspNetUsers", "dbo");

            //modelBuilder
            //    .Entity<IdentityRole>()
            //    .ToTable("AspNetRoles", "dbo");

            //modelBuilder
            //    .Entity<IdentityUserRole>()
            //    .ToTable("AspNetUserRoles", "dbo");

            //modelBuilder
            //    .Entity<IdentityUserLogin>()
            //    .ToTable("AspNetUserLogins", "dbo");

            //modelBuilder
            //    .Entity<IdentityUserClaim>()
            //    .ToTable("AspNetUserClaims", "dbo");
        }
    }
}

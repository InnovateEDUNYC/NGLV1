using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using NGL.Web.Data.Entities;
using NGL.Web.Data.EntityConfigurations;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("edfi");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new StudentAddressConfiguration());
            modelBuilder.Configurations.Add(new StudentLanguageConfiguration());
            modelBuilder.Configurations.Add(new StudentLanguageUseConfiguration());
            modelBuilder.Configurations.Add(new ParentAddressConfiguration());
            modelBuilder.Configurations.Add(new ParentElectronicMailConfiguration());
            modelBuilder.Configurations.Add(new ParentTelephoneConfiguration());
            modelBuilder.Configurations.Add(new StudentRaceConfiguration());

        }

        public virtual DbSet<EducationOrganization> EducationOrganizations { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<School> Schools { get; set; }
    }
}

using System.Configuration;
using System.Data.Entity;
using System.Reflection;
using DbUp;
using NGL.Web.Data;

namespace NGL.Web
{
    public partial class Startup
    {
        public void ConfigureDatabase()
        {
            Database.SetInitializer<NglDbContext>(null);

            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            upgrader.PerformUpgrade();
        }
    }
}
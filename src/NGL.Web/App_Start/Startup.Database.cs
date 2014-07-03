using System;
using System.Configuration;
using System.Data.Entity;
using System.Reflection;
using DbUp;
using NGL.Web.Data;
using NGL.Web.Data.Entities;

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

            var result = upgrader.PerformUpgrade();
            if(!result.Successful)
                throw new Exception(result.Error.Message);
        }
    }
}
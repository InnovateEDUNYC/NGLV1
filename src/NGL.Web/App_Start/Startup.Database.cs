using System;
using System.Configuration;
using System.Data.Entity;
using System.Reflection;
using DbUp;
using NGL.Web.Data.Entities;

namespace NGL.Web
{
    public partial class Startup
    {
        public void ConfigureDatabase()
        {
            Database.SetInitializer<NglDbContext>(null);

            Func<string, bool> scriptsOnly = s => s.EndsWith(".sql");
            Func<string, bool> filter = scriptsOnly;

            string includeSampleScripts = ConfigurationManager.AppSettings["dbup:IncludeSampleScripts"];
            if (includeSampleScripts == null || !bool.Parse(includeSampleScripts))
                filter = s => scriptsOnly(s) && !s.EndsWith(".sample.sql");
            
            var upgrader =
                DeployChanges.To
                    .SqlDatabase(DatabaseManager.ConnectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), filter)
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();
            if(!result.Successful)
                throw new Exception(result.Error.Message);
        }
    }
}
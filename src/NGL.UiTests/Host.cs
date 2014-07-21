using System;
using System.Diagnostics;
using System.IO;
using NGL.Web;
using NGL.Web.Data;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using Ninject;
using TestStack.Seleno.Configuration;
using TestStack.Seleno.Configuration.ControlIdGenerators;

namespace NGL.UiTests
{
    public static class Host
    {
        static SelenoHost _instance;
        static IKernel _ninject;

        public static SelenoHost Instance
        {
            get
            {
                _instance.Application.Browser.Manage().Cookies.DeleteAllCookies();
                return _instance;
            }
        }

        public static IKernel Locator
        {
            get { return _ninject; }
        }

        static Host()
        {
            StopIisExpress();
            DatabaseManager.RefreshDatabase();
            SetupNinject();
            RunIisExpress();
        }

        private static void SetupNinject()
        {
            _ninject = new StandardKernel();
            _ninject.Bind<INglDbContext>().To<NglDbContext>().WithConstructorArgument(ConfigManager.GetEdmxConnectionString(DatabaseManager.ConnectionString));
            _ninject.Bind<IGenericRepository>().To<GenericRepository>();
        }

        private static void RunIisExpress()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SelenoScreenShots");

            _instance = new SelenoHost();
            _instance.Run("NGL.Web", 12345, c =>
                c.WithRouteConfig(RouteConfig.RegisterRoutes)
                    .UsingControlIdGenerator(new MvcControlIdGenerator())
                    .WithEnvironmentVariable("ConnectionString", DatabaseManager.ConnectionString)
                    .UsingCamera(filePath));
        }

        static void StopIisExpress()
        {
            var iisexpress = Process.GetProcessesByName("IISExpress");
            foreach (var process in iisexpress)
            {
                process.Kill();
            }
        }
    }
}
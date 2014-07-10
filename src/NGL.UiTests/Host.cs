using System;
using System.IO;
using NGL.Web;
using TestStack.Seleno.Configuration;
using TestStack.Seleno.Configuration.ControlIdGenerators;

namespace NGL.UiTests
{
    public static class Host
    {
        static readonly SelenoHost _instance;

        public static SelenoHost Instance
        {
            get
            {
                _instance.Application.Browser.Manage().Cookies.DeleteAllCookies();
                return _instance;
            }
        }

        static Host()
        {
            DatabaseManager.RefreshDatabase();

            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SelenoScreenShots");

            _instance = new SelenoHost();
            _instance.Run("NGL.Web", 12345, c => 
                c.WithRouteConfig(RouteConfig.RegisterRoutes)
                 .UsingControlIdGenerator(new MvcControlIdGenerator())
                 .WithEnvironmentVariable("ConnectionString", DatabaseManager.ConnectionString)
                 .UsingCamera(filePath));
        }
    }
}
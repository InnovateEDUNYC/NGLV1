using NGL.Web;
using TestStack.Seleno.Configuration;

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
            _instance = new SelenoHost();
            _instance.Run("NGL.Web", 12345, c => c.WithRouteConfig(RouteConfig.RegisterRoutes));
        }
    }
}
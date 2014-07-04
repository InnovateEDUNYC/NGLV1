using NGL.Web;
using TestStack.Seleno.Configuration;

namespace NGL.UiTests
{
    public static class Host
    {
        public static readonly SelenoHost Instance = new SelenoHost();

        static Host()
        {
            Instance.Run("NGL.Web", 12345, c => c.WithRouteConfig(RouteConfig.RegisterRoutes));
        }
    }
}
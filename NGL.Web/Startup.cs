using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NGL.Web.Startup))]
namespace NGL.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

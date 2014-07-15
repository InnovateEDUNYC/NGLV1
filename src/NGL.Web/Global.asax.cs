using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ChameleonForms;
using StackExchange.Profiling;

namespace NGL.Web
{
    public class NglApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            HumanizedLabels.Register();
        }

        protected void Application_BeginRequest()
        {
            if (Request.IsLocal)
            {
                MiniProfiler.Start();
            } 
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            if (Request.IsLocal)
            {
                MiniProfiler.Stop();
            }
        }
    }
}

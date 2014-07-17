using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ChameleonForms;
using NGL.Web.Controllers;
using StackExchange.Profiling;

namespace NGL.Web
{
    public class NglApplication : HttpApplication
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

        protected void Application_Error(object sender, EventArgs e)
        {
            var httpException = Server.GetLastError() as HttpException;

            if (httpException != null && httpException.GetHttpCode() == 404)
                return;

            Response.Clear();

            var routeData = new RouteData();
            routeData.Values.Add("action", "General");
            routeData.Values.Add("controller", "Error");

            // Clear the error on server.
            Server.ClearError();

            // Avoid IIS7 getting in the middle
            Response.TrySkipIisCustomErrors = true;

            // Call target Controller and pass the routeData.
            IController errorController = new ErrorController();
            errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }
    }
}

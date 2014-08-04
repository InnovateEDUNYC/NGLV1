using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using FluentValidation.Mvc;
using NGL.Web.App_Start;
using NGL.Web.Controllers;
using NGL.Web.Infrastructure;
using NGL.Web.Infrastructure.Security;
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

            SetupValidationAndMetadata();
        }

        private static void SetupValidationAndMetadata()
        {
            var factory = new NinjectValidatorFactory();
            var fluentValidationModelValidatorProvider =
                new FluentValidationModelValidatorProvider(factory)
                {
                    AddImplicitRequiredValidator = false
                };
            ModelValidatorProviders.Providers.Add(fluentValidationModelValidatorProvider);
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            ModelMetadataProviders.Current = new CustomModelMetadataProvider(factory);
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

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                if (authTicket.UserData == "OAuth") return;
                NglPrincipalSerializedModel serializeModel = serializer.Deserialize<NglPrincipalSerializedModel>(authTicket.UserData);
                NglPrincipal newUser = new NglPrincipal(authTicket.Name);
                newUser.Resources = serializeModel.Resources;
                HttpContext.Current.User = newUser;
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Response.Clear();

            var routeData = new RouteData();
            routeData.Values.Add("controller", "Error");

            var httpException = Server.GetLastError() as HttpException;
            if (httpException != null && httpException.GetHttpCode() == 404)
                routeData.Values.Add("action", "HttpError404");
            else
                routeData.Values.Add("action", "General");

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

using System;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;

namespace NGL.Web.Infrastructure
{
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AccessProvideTo : AuthorizeAttribute
    {
        public string Resource { get; set; }
        public string Operation { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.Roles = ResourceService.GetAuthorizedRolesFor(Resource, Operation);
            base.OnAuthorization(filterContext);
            CheckIfUserIsAuthenticated(filterContext);
        }

        private void CheckIfUserIsAuthenticated(AuthorizationContext filterContext)
        {
            // If Result is null, the user is authenticated and authorized
            if (filterContext.Result == null)
                return;

            // Return Forbidden view if user is authenticated but not authorized 
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var result = new ViewResult { ViewName = "Forbidden", MasterName = String.Empty };
                filterContext.Result = result;
            }
        }
    }

    public static class ResourceService
    {
        public static string GetAuthorizedRolesFor(string resource, string operation)
        {
            return "Master Admin";
        }
    }
}
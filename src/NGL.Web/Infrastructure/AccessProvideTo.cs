using System;
using System.Web.Mvc;

namespace NGL.Web.Infrastructure
{
    public class AccessProvideTo : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
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
}
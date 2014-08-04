using System;
using System.Web;
using System.Web.Mvc;

namespace NGL.Web.Infrastructure.Security
{
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AuthorizeFor : AuthorizeAttribute
    {
        public string Resource { get; set; }
        public string Operation { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            CheckIfUserIsAuthenticated(filterContext);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var nglPrincipal = httpContext.User as NglPrincipal;

            if (!nglPrincipal.Identity.IsAuthenticated)
            {
                return false;
            }

            return nglPrincipal.HasAccessTo(Resource, Operation);
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
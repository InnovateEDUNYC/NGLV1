using System.Security.Principal;

namespace NGL.Web.Infrastructure.Security
{
    public class NglPrincipal : INglPrincipal
    {
        public IIdentity Identity { get; private set; }

        public NglPrincipal(string username)
        {
            this.Identity = new GenericIdentity(username);
        }

        public bool IsInRole(string role)
        {
            return false;
        }

        public string Resources { get; set; }
        public bool HasAccessTo(string resource, string operation)
        {
            return Resources.Contains(resource + "." + operation);
        }
    }
}
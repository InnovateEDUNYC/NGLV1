using System.Security.Principal;
using System.Web.Security;

namespace NGL.Web.Infrastructure.Security
{
    public interface INglPrincipal : IPrincipal
    {
        string Resources { get; set; }

        bool HasAccessTo(string resource, string operation);
    }

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

    public class NglPrincipalSerializedModel
    {
        public string Resources { get; set; }
    }
}
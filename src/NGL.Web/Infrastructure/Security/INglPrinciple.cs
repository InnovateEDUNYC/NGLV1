using System.Security.Principal;

namespace NGL.Web.Infrastructure.Security
{
    public interface INglPrincipal : IPrincipal
    {
        string Resources { get; set; }

        bool HasAccessTo(string resource, string operation);
    }
}
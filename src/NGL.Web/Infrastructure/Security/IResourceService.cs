using NGL.Web.Data.Entities;

namespace NGL.Web.Infrastructure.Security
{
    public interface IResourceService
    {
        string GetResourcesFor(ApplicationRole role);
    }
}

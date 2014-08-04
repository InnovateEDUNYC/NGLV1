using NGL.Web.Data.Entities;

namespace NGL.Web.Infrastructure.Security
{
    public class ResourceService : IResourceService
    {
        public string GetResourcesFor(ApplicationRole role)
        {
            switch (role)
            {
                case ApplicationRole.MasterAdmin:
                    return "session.create session.edit session.view";
                case ApplicationRole.Admin:
                    return "session.edit session.view";
                case ApplicationRole.Teacher:
                    return "session.view";
            }

            return string.Empty;
        }
    }
}
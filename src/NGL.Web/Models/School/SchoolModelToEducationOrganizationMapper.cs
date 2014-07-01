using NGL.Web.Data.Entities;

namespace NGL.Web.Models.School
{
    public class SchoolModelToEducationOrganizationMapper :
        IMapper<SchoolModel, EducationOrganization>
    {
        public void Map(SchoolModel source, EducationOrganization target)
        {
            target.NameOfInstitution = source.NameOfInstitution;
            target.StateOrganizationId = source.StateOrganizationId;
            target.WebSite = source.WebSite;
        }
    }
}
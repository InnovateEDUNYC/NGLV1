using NGL.Web.Data.Entities;

namespace NGL.Web.Models.School
{
    public class SchoolModelToEducationOrganizationMapper : 
        IMapper<EducationOrganization, SchoolModel>
    {
        public void Map(EducationOrganization source, SchoolModel target)
        {
            target.Id = source.Id;
            target.NameOfInstitution = source.NameOfInstitution;
            target.StateOrganizationId = target.StateOrganizationId;
            target.WebSite = target.StateOrganizationId;
        }
    }
}
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.School
{
    public class SchoolModelToEducationOrganizationMapper : MapperBase<SchoolModel, EducationOrganization>
    {
        public override void Map(SchoolModel source, EducationOrganization target)
        {
            target.NameOfInstitution = source.NameOfInstitution;
            target.StateOrganizationId = source.StateOrganizationId;
            target.WebSite = source.WebSite;
        }
    }
}
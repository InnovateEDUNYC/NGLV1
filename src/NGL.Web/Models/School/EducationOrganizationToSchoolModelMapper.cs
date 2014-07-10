using NGL.Web.Data.Entities;

namespace NGL.Web.Models.School
{
    public class EducationOrganizationToSchoolModelMapper : MapperBase<EducationOrganization, SchoolModel>
    {
        public override void Map(EducationOrganization source, SchoolModel target)
        {
            target.NameOfInstitution = source.NameOfInstitution;
            target.StateOrganizationId = source.StateOrganizationId;
            target.WebSite = source.WebSite;
        }
    }
}
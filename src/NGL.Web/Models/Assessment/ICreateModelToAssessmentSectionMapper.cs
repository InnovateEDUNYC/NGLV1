using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Assessment
{
    public interface ICreateModelToAssessmentSectionMapper
    {
        AssessmentSection Build(CreateModel source, Data.Entities.Assessment assessment);
    }
}
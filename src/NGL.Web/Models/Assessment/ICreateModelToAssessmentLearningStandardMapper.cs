using System;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Assessment
{
    public interface ICreateModelToAssessmentLearningStandardMapper
    {
        AssessmentLearningStandard Build(CreateModel source, Data.Entities.Assessment assessment);
    }
}

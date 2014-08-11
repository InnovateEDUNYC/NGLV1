using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class AssessmentSectionBuilder
    {
        private readonly Web.Data.Entities.Section _section = new SectionBuilder().Build(); 
        public AssessmentSection Build()
        {
            return new AssessmentSection
            {
                Section = _section
            };
        }
    }
}
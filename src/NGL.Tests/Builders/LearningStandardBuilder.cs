using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class LearningStandardBuilder
    {
        private const string Description = "English - Reading Comprehension";

        public LearningStandard Build()
        {
            return new LearningStandard{Description = Description};
        }
    }
}
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Queries
{
    public class GradeLevelTypeDescriptorQuery : IQuery<GradeLevelDescriptor>
    {
        private readonly int _gradeLevel;

        public GradeLevelTypeDescriptorQuery(int gradeLevel)
        {
            _gradeLevel = gradeLevel;
        }

        public IQueryable<GradeLevelDescriptor> ApplyPredicate(IQueryable<GradeLevelDescriptor> inputSet)
        {
            return inputSet.Where(m => m.GradeLevelTypeId == _gradeLevel);
        }
    }
}
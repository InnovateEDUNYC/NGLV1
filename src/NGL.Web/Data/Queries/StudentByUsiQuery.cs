using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Queries
{
    public class StudentByUsiQuery : IQuery<Student>
    {
        private readonly int _id;

        public StudentByUsiQuery(int id)
        {
            _id = id;
        }

        public IQueryable<Student> ApplyPredicate(IQueryable<Student> inputSet)
        {
            return inputSet.Where(s => s.StudentUSI == _id);
        }
    }
}
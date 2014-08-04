using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class SchoolBuilder
    {
        public School Build()
        {
            return new School
            {
                SchoolId = 1,
            };
        }
    }
}

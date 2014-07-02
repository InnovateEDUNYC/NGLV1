using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Repositories
{
    public interface ISchoolRepository : IRepositoryBase
    {
        School GetSchool();
    }
}
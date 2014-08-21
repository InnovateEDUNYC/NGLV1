
using NGL.Web.Data.Entities;

namespace NGL.Web.Data.Repositories
{
    public interface IStudentRepository
    {
        Student GetByUSI(int studentUsi);
    }
}

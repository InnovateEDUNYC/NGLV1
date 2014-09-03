using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGL.Web.Data.Repositories
{
    public interface ICourseRepository
    {
        void Delete(int id);
        bool HasDependencies(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGL.Web.Models.Student
{
    public class StudentToStudentIndexModelMapper : IMapper<NGL.Web.Data.Entities.Student, StudentIndexModel>
    {
        public void Map(Data.Entities.Student source, StudentIndexModel target)
        {
            target.FirstName = source.FirstName;
            target.LastName = source.LastSurname;
            target.StudentUsi = source.StudentUSI;
        }
    }
}
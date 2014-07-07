using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGL.Web.Models.Student
{
    public class StudentToEnrollmentModelMapper : IMapper<NGL.Web.Data.Entities.Student, EnrollmentModel>
    {
        public void Map(Data.Entities.Student source, EnrollmentModel target)
        {
            target.FirstName = source.FirstName;
            target.LastSurname = source.LastSurname;
            target.StudentUsi = source.StudentUSI;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGL.Web.Models.Assessment
{
    public class StudentToEnterResultsStudentModelMapper : MapperBase<Data.Entities.Student, EnterResultsStudentModel>
    {
        public override void Map(Data.Entities.Student source, EnterResultsStudentModel target)
        {
            target.StudentUsi = source.StudentUSI;
            target.Name = source.FirstName + " " + source.LastSurname;

        }
    }
}
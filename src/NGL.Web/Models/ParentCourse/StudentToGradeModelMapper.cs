using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGL.Web.Models.ParentCourse
{
    public class StudentToGradeModelMapper : MapperBase<Web.Data.Entities.Student, GradeModel>
    {
        public override void Map(Data.Entities.Student source, GradeModel target)
        {
            target.StudentFirstName = source.FirstName;
            target.StudentLastName = source.LastSurname;
            target.StudentUSI = source.StudentUSI;
        }
    }
}
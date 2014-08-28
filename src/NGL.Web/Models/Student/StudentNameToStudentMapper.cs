using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGL.Web.Models.Student
{
    public class StudentNameToStudentMapper : MapperBase<NameModel, Data.Entities.Student>
    {
        public override void Map(NameModel source, Data.Entities.Student target)
        {
            target.FirstName = source.FirstName;
            target.LastSurname = source.LastName;
        }
    }
}
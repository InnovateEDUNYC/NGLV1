using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.ParentCourse
{
    public class ParentCourseToParentGradesModelMapper : MapperBase<Web.Data.Entities.ParentCourse, List<Grade>>
    {
        public override void Map(Data.Entities.ParentCourse source, List<Grade> target)
        {
            target = new List<Grade>();
        }
    }
}
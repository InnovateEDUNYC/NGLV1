using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.ParentCourse
{
    public class SectionAndGradeToParentCourseGradeMapper : MapperBase<Web.Data.Entities.Section, Web.Data.Entities.ParentCourseGrade>
    {
        public override void Map(Data.Entities.Section source, ParentCourseGrade target)
        {
            throw new NotImplementedException();
        }
    }
}
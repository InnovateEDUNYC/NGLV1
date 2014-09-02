using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGL.Web.Models.ParentCourse
{
    public class ParentCourseToEditModelMapper : MapperBase<Data.Entities.ParentCourse, EditModel>
    {
        public override void Map(Data.Entities.ParentCourse source, EditModel target)
        {
            target.ParentCourseCode = source.ParentCourseCode;
            target.ParentCourseDescription = source.ParentCourseDescription;
            target.ParentCourseId = source.Id;
            target.ParentCourseTitle = source.ParentCourseTitle;
        }
    }
}
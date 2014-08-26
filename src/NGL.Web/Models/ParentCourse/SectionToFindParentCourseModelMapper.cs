using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGL.Web.Models.ParentCourse
{
    public class SectionToFindParentCourseModelMapper : MapperBase<Web.Data.Entities.Section, FindParentCourseModel>
    {
        public override void Map(Data.Entities.Section source, FindParentCourseModel target)
        {
            target.ParentCourse = source.UniqueSectionCode;
            target.ParentCourseId = source.SectionIdentity;
            target.Session = source.Session.SessionName;
            target.SessionId = source.Session.SessionIdentity;
        }
    }
}
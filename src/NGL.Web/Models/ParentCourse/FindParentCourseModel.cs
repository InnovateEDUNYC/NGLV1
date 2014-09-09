using System;

namespace NGL.Web.Models.ParentCourse
{
    public class FindParentCourseModel
    {
        public string Session { get; set; }
        public int? SessionId { get; set; }
        public string ParentCourse { get; set; }
        public Guid? ParentCourseId { get; set; }
    }
}
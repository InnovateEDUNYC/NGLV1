﻿using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGL.Web.Models.ParentCourse
{
    public class FindParentCourseModel
    {
        public string Session { get; set; }
        public int? SessionId { get; set; }
        public string ParentCourse { get; set; }
        public int? ParentCourseId { get; set; }
    }
}
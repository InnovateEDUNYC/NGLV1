using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGL.Web.Models.ParentCourse
{
    public class ParentCourseGradesModel
    {
        public FindParentCourseModel FindParentCourseModel { get; set; }
        public List<GradeModel> ParentGradesModelList { get; set; }
    }
}
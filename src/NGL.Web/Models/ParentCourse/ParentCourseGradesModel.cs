using System.Collections.Generic;

namespace NGL.Web.Models.ParentCourse
{
    public class ParentCourseGradesModel
    {
        public FindParentCourseModel FindParentCourseModel { get; set; }
        public List<GradeModel> ParentGradesModelList { get; set; }
    }
}
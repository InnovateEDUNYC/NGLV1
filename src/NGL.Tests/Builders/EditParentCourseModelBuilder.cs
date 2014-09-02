using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGL.Web.Models.ParentCourse;

namespace NGL.Tests.Builders
{
    public class EditParentCourseModelBuilder
    {
        private string _parentCourseCode = "Creative Drama 1";
        private string _parentCourseTitle = "Drama for artists";
        private string _parentCourseDescription = "somthing deep";
        private Guid _id = Guid.Parse("F43C1E50-1FEA-4D11-B98E-3DBA89999F18");

        public EditModel Build()
        {
            return new EditModel
            {
                ParentCourseCode = _parentCourseCode,
                ParentCourseTitle = _parentCourseTitle,
                ParentCourseDescription = _parentCourseDescription,
                ParentCourseId = _id
            };
        }
    }
}

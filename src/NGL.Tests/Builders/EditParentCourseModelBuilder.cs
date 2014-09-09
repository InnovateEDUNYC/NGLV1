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
        private const string ParentCourseCode = "Creative Drama 1";
        private const string ParentCourseTitle = "Drama for artists";
        private const string ParentCourseDescription = "somthing deep";
        private readonly Guid _id = Guid.Parse("F43C1E50-1FEA-4D11-B98E-3DBA89999F18");

        public EditModel Build()
        {
            return new EditModel
            {
                ParentCourseCode = ParentCourseCode,
                ParentCourseTitle = ParentCourseTitle,
                ParentCourseDescription = ParentCourseDescription,
                ParentCourseId = _id
            };
        }
    }
}

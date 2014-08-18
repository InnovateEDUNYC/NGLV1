using NGL.Web.Models.ParentCourse;

namespace NGL.Tests.Builders
{
    public class CreateParentCourseModelBuilder
    {
        private string _parentCourseCode;
        private string _parentCourseTitle;
        private string _parentCourseDescription;

        public CreateModel Build()
        {
            _parentCourseCode = "Drama 101";
            _parentCourseTitle = "Drama and Comedy";
            _parentCourseDescription = "Laugh and Cry";
            return new CreateModel
            {
                ParentCourseCode = _parentCourseCode,
                ParentCourseTitle = _parentCourseTitle,
                ParentCourseDescription = _parentCourseDescription
            };
        }
    }
}

using System;

namespace NGL.Tests.Builders
{
    public class ParentCourseBuilder
    {
        private string _parentCourseCode = "la";
        private const string ParentCourseDescription = "desc";
        private const string ParentCourseTitle = "title";

        public Web.Data.Entities.ParentCourse Build()
        {
            return new Web.Data.Entities.ParentCourse
            {
                EducationOrganizationId = Constants.EducationOrganizationId,
                ParentCourseCode = _parentCourseCode,
                ParentCourseDescription = ParentCourseDescription,
                ParentCourseTitle = ParentCourseTitle,
                Id = Guid.NewGuid()
            };
        }

        public ParentCourseBuilder WithCourseCode(string courseCode)
        {
            _parentCourseCode = courseCode;
            return this;
        }
    }
}

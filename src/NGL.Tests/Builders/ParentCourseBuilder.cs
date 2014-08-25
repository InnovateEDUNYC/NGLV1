using System;

namespace NGL.Tests.Builders
{
    public class ParentCourseBuilder
    {
        private string _parentCourseCode = "la";
        private string _parentCourseDescription = "desc";
        private string _parentCourseTitle = "title";

        public Web.Data.Entities.ParentCourse Build()
        {
            return new Web.Data.Entities.ParentCourse
            {
                EducationOrganizationId = Constants.EducationOrganizationId,
                ParentCourseCode = _parentCourseCode,
                ParentCourseDescription = _parentCourseDescription,
                ParentCourseTitle = _parentCourseTitle,
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

namespace NGL.Tests.Builders
{
    public class ParentCourseBuilder
    {
        public Web.Data.Entities.ParentCourse Build()
        {
            return new Web.Data.Entities.ParentCourse()
            {
                EducationOrganizationId = Constants.EducationOrganizationId,
                ParentCourseCode = "la",
                ParentCourseDescription = "desc",
                ParentCourseTitle = "title"
            };
        }
    }
}

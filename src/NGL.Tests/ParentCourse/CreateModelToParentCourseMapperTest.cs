using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Repositories;
using NGL.Web.Models.ParentCourse;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.ParentCourse
{
    public class CreateModelToParentCourseMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var schoolRepository = Substitute.For<ISchoolRepository>();
            schoolRepository.GetSchool().Returns(
                new School
                {
                    EducationOrganization = new EducationOrganization { EducationOrganizationId = 1 }
                });

            CreateModel model =  new CreateParentCourseModelBuilder().Build();
            var mapper = new CreateModelToParentCourseMapper(schoolRepository);

            Web.Data.Entities.ParentCourse parentCourse = mapper.Build(model);

            parentCourse.EducationOrganizationId.ShouldBe(1);
            parentCourse.ParentCourseCode.ShouldBe("Drama 101");
            parentCourse.ParentCourseTitle.ShouldBe("Drama and Comedy");
            parentCourse.ParentCourseDescription.ShouldBe("Laugh and Cry");
        }
    }
}

using NGL.Web.Data.Entities;
using NGL.Web.Data.Repositories;
using NGL.Web.Models.Section;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Section
{
    public class CreateModelToCourseOfferingMapperTests
    {
        private ISchoolRepository _schoolRepository;

        [Fact]
        public void ShouldMap()
        {
            Setup();

            var model = new CreateSectionModelBuilder().Build();
            var entity = new CreateModelToCourseOfferingMapper(_schoolRepository).Build(model);

            entity.EducationOrganizationId.ShouldBe(Constants.EducationOrganizationId);
            entity.SchoolId.ShouldBe(Constants.SchoolId);
            entity.TermTypeId.ShouldBe((int) model.Term);
            entity.SchoolYear.ShouldBe((short) model.SchoolYear);
            entity.CourseCode.ShouldBe(model.Course);
            entity.LocalCourseCode.ShouldBe(model.Course);
        }

        private void Setup()
        {
            _schoolRepository = Substitute.For<ISchoolRepository>();
            _schoolRepository.GetSchool().Returns(
                new School
                {
                    SchoolId = Constants.SchoolId,
                    EducationOrganization = new EducationOrganization
                    {
                        EducationOrganizationId = Constants.EducationOrganizationId
                    }
                });
        }
    }
}

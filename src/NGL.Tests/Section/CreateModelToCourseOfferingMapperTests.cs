using System;
using System.Linq.Expressions;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
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
            entity.LocalCourseCode.ShouldBe(model.Course);
            entity.TermTypeId.ShouldBe(model.Term);
            entity.SchoolYear.ShouldBe(model.SchoolYear);
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

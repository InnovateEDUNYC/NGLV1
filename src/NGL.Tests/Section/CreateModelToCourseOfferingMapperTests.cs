using System;
using System.Linq.Expressions;
using NGL.Tests.Session;
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
        private IGenericRepository _genericRepository;
        private Web.Data.Entities.Session _session;

        [Fact]
        public void ShouldMap()
        {
            Setup();

            var model = new CreateSectionModelBuilder().Build();
            var entity = new CreateModelToCourseOfferingMapper(_schoolRepository, _genericRepository).Build(model);

            entity.EducationOrganizationId.ShouldBe(Constants.EducationOrganizationId);
            entity.SchoolId.ShouldBe(Constants.SchoolId);
            entity.LocalCourseCode.ShouldBe(model.Course);
            entity.SchoolYear.ShouldBe(_session.SchoolYear);
            entity.TermTypeId.ShouldBe(_session.TermTypeId);
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

            _session = new SessionBuilder().Build();

            _genericRepository = Substitute.For<IGenericRepository>();
            _genericRepository.Get(Arg.Any<Expression<Func<Web.Data.Entities.Session, bool>>>()).Returns(_session);


        }
    }
}

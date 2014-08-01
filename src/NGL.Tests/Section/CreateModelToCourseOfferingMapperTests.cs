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
        private IGenericRepository _genericRepository;

        [Fact]
        public void ShouldMap()
        {
            Setup();
            var courseInDB = new Web.Data.Entities.Course();
            var sessionInDB = new Web.Data.Entities.Session();

            _genericRepository.Get(Arg.Any<Expression<Func<Web.Data.Entities.Course, bool>>>())
                .Returns(courseInDB);
            _genericRepository.Get(Arg.Any<Expression<Func<Web.Data.Entities.Session, bool>>>())
                .Returns(sessionInDB);

            var model = new CreateSectionModelBuilder().Build();
            var entity = new CreateModelToCourseOfferingMapper(_genericRepository,_schoolRepository).Build(model);

            entity.EducationOrganizationId.ShouldBe(Constants.EducationOrganizationId);
            entity.SchoolId.ShouldBe(Constants.SchoolId);
            entity.Session.ShouldBe(sessionInDB);
            entity.Course.ShouldBe(courseInDB);
            entity.LocalCourseCode.ShouldBe(model.Course);
        }

        private void Setup()
        {
            _genericRepository = Substitute.For<IGenericRepository>();
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
            _genericRepository.Get(Arg.Any<Expression<Func<Web.Data.Entities.Course, bool>>>());
            _genericRepository.Get(Arg.Any<Expression<Func<Web.Data.Entities.Session, bool>>>());
        }
    }
}

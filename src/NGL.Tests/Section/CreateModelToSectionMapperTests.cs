using System;
using System.Linq.Expressions;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Models;
using NGL.Web.Models.Section;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Section
{
    public class CreateModelToSectionMapperTests
    {
        private ISchoolRepository _schoolRepository;
        private IGenericRepository _genericRepository;

        [Fact]
        public void ShouldMapCreateModelToSection()
        {
            Setup();
            var createModelToCourseOfferingMapper = Substitute.For<IMapper<CreateModel, CourseOffering>>();
            var model = new CreateSectionModelBuilder().Build();

            _genericRepository.Get(Arg.Any<Expression<Func<CourseOffering, bool>>>())
                .Returns(null as CourseOffering);


            var entity = new CreateModelToSectionMapper(_genericRepository, _schoolRepository, 
                createModelToCourseOfferingMapper).Build(model);

            entity.SchoolId.ShouldBe(Constants.SchoolId);
            entity.SchoolYear.ShouldBe((short) model.SchoolYear);
            entity.TermTypeId.ShouldBe((int) model.Term);
            entity.ClassPeriodName.ShouldBe(model.Period);
            entity.ClassroomIdentificationCode.ShouldBe(model.Classroom);
            entity.LocalCourseCode.ShouldBe(model.Course);
            entity.UniqueSectionCode.ShouldBe(model.UniqueSectionCode);
            entity.SequenceOfCourse.ShouldBe(model.SequenceOfCourse);

            createModelToCourseOfferingMapper.Received().Build(model);
        }

        [Fact]
        public void ShouldMapCreateModelToSectionWithoutCreatingNewCourseOffering()
        {
            Setup();
            var createModelToCourseOfferingMapper = Substitute.For<IMapper<CreateModel, CourseOffering>>();
            var model = new CreateSectionModelBuilder().Build();

            _genericRepository.Get(Arg.Any<Expression<Func<CourseOffering, bool>>>())
                .Returns(new CourseOffering());


            new CreateModelToSectionMapper(_genericRepository, _schoolRepository, createModelToCourseOfferingMapper).Build(model);

            createModelToCourseOfferingMapper.DidNotReceive().Build(model);
        }

        private void Setup()
        {
            _genericRepository = Substitute.For<IGenericRepository>();

            _schoolRepository = Substitute.For<ISchoolRepository>();
            _schoolRepository.GetSchool().Returns(new School
            {
                SchoolId = Constants.SchoolId,
                EducationOrganization = new EducationOrganization {EducationOrganizationId = 1}
            });
        }
    }
}

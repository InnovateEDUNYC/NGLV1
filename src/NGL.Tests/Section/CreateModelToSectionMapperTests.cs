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
        private IMapper<CreateModel, CourseOffering> _createModelToCourseOfferingMapper;

        [Fact]
        public void ShouldMapCreateModelToSection()
        {
            Setup();
            var model = new CreateSectionModelBuilder().Build();
            _genericRepository.Get(Arg.Any<Expression<Func<CourseOffering, bool>>>())
                .Returns(null as CourseOffering);

            var newCourseOffering = new CourseOffering();
            _createModelToCourseOfferingMapper.Build(model)
                .Returns(newCourseOffering);

            var entity = new CreateModelToSectionMapper(_genericRepository, _schoolRepository, 
                _createModelToCourseOfferingMapper).Build(model);


            entity.SchoolId.ShouldBe(Constants.SchoolId);
            entity.CourseOffering.ShouldBe(newCourseOffering);
            entity.ClassPeriodName.ShouldBe(model.Period);
            entity.ClassroomIdentificationCode.ShouldBe(model.Classroom);
            entity.UniqueSectionCode.ShouldBe(model.UniqueSectionCode);
            entity.SequenceOfCourse.ShouldBe(model.SequenceOfCourse);
        }

        [Fact]
        public void ShouldMapCreateModelToSectionWithoutCreatingNewCourseOffering()
        {
            Setup();
            var model = new CreateSectionModelBuilder().Build();

            _genericRepository.Get(Arg.Any<Expression<Func<CourseOffering, bool>>>())
                .Returns(new CourseOffering());

            new CreateModelToSectionMapper(_genericRepository, _schoolRepository, _createModelToCourseOfferingMapper).Build(model);

            _createModelToCourseOfferingMapper.DidNotReceive().Build(model);
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

            _createModelToCourseOfferingMapper = Substitute.For<IMapper<CreateModel, CourseOffering>>();
        }
    }
}

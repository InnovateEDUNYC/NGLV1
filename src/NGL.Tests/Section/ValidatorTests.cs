using System;
using System.Linq.Expressions;
using FluentValidation.TestHelper;
using NGL.Tests.Builders;
using NGL.Tests.Session;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;
using NGL.Web.Models.Section;
using NSubstitute;
using Xunit;

namespace NGL.Tests.Section
{
    public class ValidatorTests
    {
        private IGenericRepository _genericRepository;
        private CreateModel _sectionCreateModel;
        private CreateModelValidator _validator;

        [Fact]
        public void ShouldNotHaveErrorsIfSectionDoesNotExist()
        {
            Setup();

            _genericRepository
                .Get(Arg.Any<SectionByPrimaryKeysQuery>())
                .Returns(null as Web.Data.Entities.Section);

            _validator.ShouldNotHaveValidationErrorFor(s => s.Session, _sectionCreateModel);
            _validator.ShouldNotHaveValidationErrorFor(s => s.Period, _sectionCreateModel);
            _validator.ShouldNotHaveValidationErrorFor(s => s.Classroom, _sectionCreateModel);
            _validator.ShouldNotHaveValidationErrorFor(s => s.Course, _sectionCreateModel);
        }

        [Fact]
        public void ShouldHaveErrorsIfSectionExists()
        {
            Setup();

            var sectionEntity = new SectionBuilder().Build();

            _genericRepository
                .Get(Arg.Any<SectionByPrimaryKeysQuery>())
                .Returns(sectionEntity);

            _validator.ShouldHaveValidationErrorFor(s => s.Session, _sectionCreateModel);
            _validator.ShouldHaveValidationErrorFor(s => s.Period, _sectionCreateModel);
            _validator.ShouldHaveValidationErrorFor(s => s.Classroom, _sectionCreateModel);
            _validator.ShouldHaveValidationErrorFor(s => s.Course, _sectionCreateModel);
        }

        private void Setup()
        {
            _genericRepository = Substitute.For<IGenericRepository>();
            _sectionCreateModel = new CreateSectionModelBuilder().Build();
            _validator = new CreateModelValidator(_genericRepository);

            _genericRepository.Get(Arg.Any<Expression<Func<Web.Data.Entities.Session, bool>>>())
                .Returns(new SessionBuilder().Build());

            _genericRepository.Get(Arg.Any<Expression<Func<Web.Data.Entities.ClassPeriod, bool>>>())
                .Returns(new ClassPeriodBuilder().Build());

            _genericRepository.Get(Arg.Any<Expression<Func<Web.Data.Entities.Location, bool>>>())
                .Returns(new LocationBuilder().Build());

            _genericRepository.Get(Arg.Any<Expression<Func<Web.Data.Entities.Course, bool>>>())
                .Returns(new CourseBuilder().Build());
        }
    }
}

using System;
using System.Linq.Expressions;
using NGL.Tests.Session;
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
        private Web.Data.Entities.Session _session;

        [Fact]
        public void ShouldMapCreateModelToSection()
        {
            Setup();
            var model = new CreateSectionModelBuilder().Build();
            var entity = new CreateModelToSectionMapper(_schoolRepository, _genericRepository).Build(model);


            entity.SchoolId.ShouldBe(Constants.SchoolId);
            entity.ClassPeriodName.ShouldBe(model.Period);
            entity.ClassroomIdentificationCode.ShouldBe(model.Classroom);
            entity.LocalCourseCode.ShouldBe(model.Course);

            entity.TermTypeId.ShouldBe(_session.TermTypeId);
            entity.SchoolYear.ShouldBe(_session.SchoolYear);

            entity.UniqueSectionCode.ShouldBe(model.UniqueSectionCode);
            entity.SequenceOfCourse.ShouldBe(model.SequenceOfCourse.GetValueOrDefault());
        }

        private void Setup()
        {
            _schoolRepository = Substitute.For<ISchoolRepository>();
            _schoolRepository.GetSchool().Returns(new School
            {
                SchoolId = Constants.SchoolId,
                EducationOrganization = new EducationOrganization {EducationOrganizationId = 1}
            });

            _session = new SessionBuilder().Build();

            _genericRepository = Substitute.For<IGenericRepository>();
            _genericRepository.Get(Arg.Any<Expression<Func<Web.Data.Entities.Session, bool>>>()).Returns(_session);


        }
    }
}

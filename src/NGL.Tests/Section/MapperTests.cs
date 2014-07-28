using NGL.Web.Data.Entities;
using NGL.Web.Data.Repositories;
using NGL.Web.Models.Section;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Section
{
    public class MapperTests
    {
        private CreateModelToSectionMapper _createModelToSectionMapper;
        private ISchoolRepository _schoolRepository;


        private void Setup()
        {
            _schoolRepository = Substitute.For<ISchoolRepository>();
            _schoolRepository.GetSchool().Returns(
                new School
                {
                    SchoolId = 1
                });

            _createModelToSectionMapper = new CreateModelToSectionMapper(_schoolRepository);
        }

        [Fact]
        public void ShouldMapCreateModelToSection()
        {
            Setup();

            var createModel = new CreateModelBuilder().Build();
            var section = _createModelToSectionMapper.Build(createModel);

            section.SchoolId.ShouldBe(Constants.SchoolId);
            section.SchoolYear.ShouldBe(createModel.SchoolYear);
            section.TermTypeId.ShouldBe(createModel.TermTypeId);
            section.ClassPeriodName.ShouldBe(createModel.ClassPeriodName);
            section.ClassroomIdentificationCode.ShouldBe(createModel.ClassroomIdentificationCode);
            section.LocalCourseCode.ShouldBe(createModel.LocalCourseCode);
            section.UniqueSectionCode.ShouldBe(createModel.UniqueSectionCode);
            section.SequenceOfCourse.ShouldBe(createModel.SequenceOfCourse);
        }
    }
}

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

            var sectionCreateModel = new CreateModelBuilder().Build();
            var sectionEntity = _createModelToSectionMapper.Build(sectionCreateModel);

            sectionEntity.SchoolId.ShouldBe(Constants.SchoolId);
            sectionEntity.SchoolYear.ShouldBe(sectionCreateModel.SchoolYear);
            sectionEntity.TermTypeId.ShouldBe(sectionCreateModel.TermTypeId);
            sectionEntity.ClassPeriodName.ShouldBe(sectionCreateModel.ClassPeriodName);
            sectionEntity.ClassroomIdentificationCode.ShouldBe(sectionCreateModel.ClassroomIdentificationCode);
            sectionEntity.LocalCourseCode.ShouldBe(sectionCreateModel.LocalCourseCode);
            sectionEntity.UniqueSectionCode.ShouldBe(sectionCreateModel.UniqueSectionCode);
            sectionEntity.SequenceOfCourse.ShouldBe(sectionCreateModel.SequenceOfCourse);
        }
    }
}

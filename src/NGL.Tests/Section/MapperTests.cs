using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Repositories;
using NGL.Web.Models.Section;
using NSubstitute;
using Shouldly;
using Xunit;
using Humanizer;

namespace NGL.Tests.Section
{
    public class MapperTests
    {
        [Fact]
        public void ShouldMapCreateModelToSection()
        {
            var schoolRepository = Substitute.For<ISchoolRepository>();
            schoolRepository.GetSchool().Returns(new School { SchoolId = Constants.SchoolId });

            var sectionCreateModel = new CreateSectionModelBuilder().Build();
            var sectionEntity = new CreateModelToSectionMapper(schoolRepository).Build(sectionCreateModel);

            sectionEntity.SchoolId.ShouldBe(Constants.SchoolId);
            sectionEntity.SchoolYear.ShouldBe((short)sectionCreateModel.SchoolYear);
            sectionEntity.TermTypeId.ShouldBe((int)sectionCreateModel.Term);
            sectionEntity.ClassPeriodName.ShouldBe(sectionCreateModel.ClassPeriodName);
            sectionEntity.ClassroomIdentificationCode.ShouldBe(sectionCreateModel.ClassRoom);
            sectionEntity.LocalCourseCode.ShouldBe(sectionCreateModel.LocalCourseCode);
            sectionEntity.UniqueSectionCode.ShouldBe(sectionCreateModel.UniqueSectionCode);
            sectionEntity.SequenceOfCourse.ShouldBe(sectionCreateModel.SequenceOfCourse);
        }

        [Fact]
        public void ShouldMapSectionToIndexModel()
        {
            var sectionEntity = new SectionBuilder().Build();
            var sectionIndexModel = new SectionToIndexModelMapper().Build(sectionEntity);

            sectionIndexModel.SchoolYear.ShouldBe(((SchoolYearTypeEnum) sectionEntity.SchoolYear).Humanize());
            sectionIndexModel.Term.ShouldBe(((TermTypeEnum) sectionEntity.TermTypeId).Humanize());
            sectionIndexModel.ClassPeriod.ShouldBe(sectionEntity.ClassPeriodName);
            sectionIndexModel.Classroom.ShouldBe(sectionEntity.ClassroomIdentificationCode);
            sectionIndexModel.LocalCourseCode.ShouldBe(sectionEntity.LocalCourseCode);
            sectionIndexModel.UniqueSectionCode.ShouldBe(sectionEntity.UniqueSectionCode);
            sectionIndexModel.SequenceOfCourse.ShouldBe(sectionEntity.SequenceOfCourse);
        }

        [Fact]
        public void ShouldMapClassPeriodToClassPeriodNameModel()
        {
            var classPeriodEntity = new ClassPeriodBuilder().Build();
            var classPeriodNameModel = new ClassPeriodToClassPeriodNameModelMapper().Build(classPeriodEntity);

            classPeriodNameModel.ClassPeriodName.ShouldBe(classPeriodEntity.ClassPeriodName);
        }

        [Fact]
        public void ShouldMapLocationToClassRoom()
        {
            var locationEntity = new LocationBuilder().Build();
            var classRoomModel = new LocationToClassRoomModelMapper().Build(locationEntity);

            classRoomModel.ClassRoom.ShouldBe(locationEntity.ClassroomIdentificationCode);
        }
    }
}

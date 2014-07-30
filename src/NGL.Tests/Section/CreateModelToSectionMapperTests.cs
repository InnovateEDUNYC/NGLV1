using NGL.Web.Data.Entities;
using NGL.Web.Data.Repositories;
using NGL.Web.Models.Section;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Section
{
    public class CreateModelToSectionMapperTests
    {
        [Fact]
        public void ShouldMapCreateModelToSection()
        {
            var schoolRepository = Substitute.For<ISchoolRepository>();
            schoolRepository.GetSchool().Returns(new School
            {
                SchoolId = Constants.SchoolId,
                EducationOrganization = new EducationOrganization { EducationOrganizationId = 1}
            });

            var model = new CreateSectionModelBuilder().Build();
            var entity = new CreateModelToSectionMapper(schoolRepository, new CreateModelToCourseOfferingMapper(schoolRepository)).Build(model);

            entity.SchoolId.ShouldBe(Constants.SchoolId);
            entity.SchoolYear.ShouldBe((short) model.SchoolYear);
            entity.TermTypeId.ShouldBe((int) model.Term);
            entity.ClassPeriodName.ShouldBe(model.Period);
            entity.ClassroomIdentificationCode.ShouldBe(model.Classroom);
            entity.LocalCourseCode.ShouldBe(model.Course);
            entity.UniqueSectionCode.ShouldBe(model.UniqueSectionCode);
            entity.SequenceOfCourse.ShouldBe(model.SequenceOfCourse);
        }

    }
}

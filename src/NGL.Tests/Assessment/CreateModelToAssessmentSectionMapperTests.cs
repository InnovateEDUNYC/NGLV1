using System;
using System.Linq.Expressions;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;
using NGL.Web.Models.Assessment;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Assessment
{
    public class CreateModelToAssessmentSectionMapperTests
    {
        private CreateModel _createModel;
        private Web.Data.Entities.Assessment _assessment;
        private IGenericRepository _genericRepositoryStub;
        private Web.Data.Entities.Section _section;

        [Fact]
        public void ShouldMap()
        {
            SetUp();

            var entity = new CreateModelToCreateModelToAssessmentSectionMapper(_genericRepositoryStub).Build(_createModel, _assessment);

            entity.AssessmentTitle.ShouldBe(_assessment.AssessmentTitle);
            entity.AcademicSubjectDescriptorId.ShouldBe(_assessment.AcademicSubjectDescriptorId);
            entity.AssessedGradeLevelDescriptorId.ShouldBe(_assessment.AssessedGradeLevelDescriptorId);
            entity.Version.ShouldBe(_assessment.Version);

            entity.SchoolId.ShouldBe(Constants.SchoolId);
            entity.ClassPeriodName.ShouldBe(_section.ClassPeriodName);
            entity.ClassroomIdentificationCode.ShouldBe(_section.ClassroomIdentificationCode);
            entity.LocalCourseCode.ShouldBe(_section.LocalCourseCode);

            entity.TermTypeId.ShouldBe(_section.TermTypeId);
            entity.SchoolYear.ShouldBe(_section.SchoolYear);

            _assessment.AssessmentSections.Count.ShouldBe(1);
        }

        private void SetUp()
        {
            _createModel = new CreateAssessmentModelBuilder().Build();
            _assessment = new AssessmentBuilder()
                .WithAssessmentLearningStandards()
                .WithAssessmentPerformanceLevels()
                .Build();

            _genericRepositoryStub = Substitute.For<IGenericRepository>();
            _section = new SectionBuilder().Build();

            var fourthGradeLevelDescriptor = new GradeLevelDescriptor
            {
                GradeLevelDescriptorId = 99,
                GradeLevelTypeId = 100
            };

            _genericRepositoryStub.Get(Arg.Any<GradeLevelTypeDescriptorQuery>()).Returns( fourthGradeLevelDescriptor);

            _genericRepositoryStub.Get(Arg.Any<Expression<Func<Web.Data.Entities.Section, bool>>>())
                                .Returns(_section);
        }
    }
}

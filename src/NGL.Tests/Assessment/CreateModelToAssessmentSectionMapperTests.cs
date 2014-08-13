using System;
using System.Linq.Expressions;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Expressions;
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
        private GradeLevelDescriptor _4ThGradeLevelDescriptor;
        private CreateModel _createModel;
        private Web.Data.Entities.Assessment _assessment;
        private IGenericRepository _genericRepositoryStub;
        private Web.Data.Entities.Section _section;
        private AssessmentMapperExpression _assessmentMapperExpression;

        [Fact]
        public void ShouldMap()
        {
            SetUp();

            var entity = new CreateModelToAssessmentSectionMapper(_genericRepositoryStub).Build(_createModel,
               _assessmentMapperExpression.SectionExpression);

            entity.AssessmentTitle.ShouldBe(_createModel.AssessmentTitle);
            entity.AcademicSubjectDescriptorId.ShouldBe(_assessment.AcademicSubjectDescriptorId);
            entity.AssessedGradeLevelDescriptorId.ShouldBe(_4ThGradeLevelDescriptor.GradeLevelDescriptorId);
            entity.Version.ShouldBe(_assessment.Version);

            entity.SchoolId.ShouldBe(Constants.SchoolId);
            entity.ClassPeriodName.ShouldBe(_section.ClassPeriodName);
            entity.ClassroomIdentificationCode.ShouldBe(_section.ClassroomIdentificationCode);
            entity.LocalCourseCode.ShouldBe(_section.LocalCourseCode);

            entity.TermTypeId.ShouldBe(_section.TermTypeId);
            entity.SchoolYear.ShouldBe(_section.SchoolYear);
        }

        private void SetUp()
        {
            _createModel = new CreateModelBuilder().Build();
            _assessment = new AssessmentBuilder()
                .WithAssessmentLearningStandards()
                .WithAssessmentPerformanceLevels()
                .Build();

            _genericRepositoryStub = Substitute.For<IGenericRepository>();
            _section = new SectionBuilder().Build();
            _assessmentMapperExpression = new AssessmentMapperExpression(_assessment);

            _4ThGradeLevelDescriptor = new GradeLevelDescriptor
            {
                GradeLevelDescriptorId = 99,
                GradeLevelTypeId = 100
            };

            _genericRepositoryStub.Get(Arg.Any<GradeLevelTypeDescriptorQuery>()).Returns(_4ThGradeLevelDescriptor);

            _genericRepositoryStub.Get(Arg.Any<Expression<Func<Web.Data.Entities.Section, bool>>>())
                                .Returns(_section);
        }
    }
}

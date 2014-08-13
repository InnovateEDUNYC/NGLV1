﻿using NGL.Tests.Builders;
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
    public class CreateModelToAssessmentLearningStandardMapperTests
    {
        private IGenericRepository _genericRepositoryStub;
        private GradeLevelDescriptor _4ThGradeLevelDescriptor;
        private Web.Data.Entities.Assessment _assessment;
        private CreateModel _createModel;
        private AssessmentMapperExpression _assessmentMapperExpression;

        [Fact]
        public void ShouldMap()
        {
            SetUp();

            var entity = new CreateModelToAssessmentLearningStandardMapper(_genericRepositoryStub).Build(_createModel,
                            _assessmentMapperExpression.LearningStandardExpression);

            entity.AssessmentTitle.ShouldBe(_createModel.AssessmentTitle);
            entity.AcademicSubjectDescriptorId.ShouldBe(_assessment.AcademicSubjectDescriptorId);
            entity.AssessedGradeLevelDescriptorId.ShouldBe(_4ThGradeLevelDescriptor.GradeLevelDescriptorId);
            entity.Version.ShouldBe(_assessment.Version);

            entity.LearningStandardId.ShouldBe(_createModel.CommonCoreStandard);
        }

        private void SetUp()
        {
            _createModel = new CreateModelBuilder().Build();
            _assessment = new AssessmentBuilder()
                .WithAssessmentLearningStandards()
                .WithAssessmentPerformanceLevels()
                .Build();

            _genericRepositoryStub = Substitute.For<IGenericRepository>();
            _assessmentMapperExpression = new AssessmentMapperExpression(_assessment);

            _4ThGradeLevelDescriptor = new GradeLevelDescriptor
            {
                GradeLevelDescriptorId = 99,
                GradeLevelTypeId = 100
            };

            _genericRepositoryStub.Get(Arg.Any<GradeLevelTypeDescriptorQuery>()).Returns(_4ThGradeLevelDescriptor);
        }
    }
}

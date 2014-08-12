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
    public class CreateModelToAssessmentPerformanceLevelMapperTests
    {
        private IGenericRepository _genericRepositoryStub;
        private GradeLevelDescriptor _4ThGradeLevelDescriptor;
        private const PerformanceLevelDescriptorEnum MasteryPerformanceLevelDescriptor = PerformanceLevelDescriptorEnum.Mastery;
        private Web.Data.Entities.Assessment _assessment;
        private CreateModel _createModel;

        [Fact]
        public void ShouldMap()
        {
            SetUp();

            var assessmentPerformanceLevel = new CreateModelToAssessmentPerformanceLevelMapper(_genericRepositoryStub).BuildWithPerformanceLevel(_createModel, _assessment, MasteryPerformanceLevelDescriptor);

            assessmentPerformanceLevel.AcademicSubjectDescriptorId.ShouldBe(_assessment.AcademicSubjectDescriptorId);
            assessmentPerformanceLevel.Version.ShouldBe(_assessment.Version);

            assessmentPerformanceLevel.MinimumScore.ShouldBe(_createModel.Mastery.ToString());
            assessmentPerformanceLevel.AssessmentTitle.ShouldBe(_createModel.AssessmentTitle);
            assessmentPerformanceLevel.AssessedGradeLevelDescriptorId.ShouldBe(_4ThGradeLevelDescriptor.GradeLevelDescriptorId);
            assessmentPerformanceLevel.AssessmentReportingMethodTypeId.ShouldBe((int) _createModel.ReportingMethod);
            assessmentPerformanceLevel.PerformanceLevelDescriptorId.ShouldBe((int) MasteryPerformanceLevelDescriptor);
        }

        private void SetUp()
        {
            _createModel = new CreateModelBuilder().Build();
            _assessment = new AssessmentBuilder().Build();
            _genericRepositoryStub = Substitute.For<IGenericRepository>();

            _4ThGradeLevelDescriptor = new GradeLevelDescriptor
            {
                GradeLevelDescriptorId = 99,
                GradeLevelTypeId = 100
            };

            _genericRepositoryStub.Get(Arg.Any<GradeLevelTypeDescriptorQuery>())
                                .Returns(_4ThGradeLevelDescriptor);
        }
    }
}

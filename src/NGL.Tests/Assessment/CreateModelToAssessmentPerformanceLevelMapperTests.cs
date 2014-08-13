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
        private const PerformanceLevelDescriptorEnum MasteryPerformanceLevelDescriptor = PerformanceLevelDescriptorEnum.Mastery;
        private Web.Data.Entities.Assessment _assessment;
        private CreateModel _createAssessmentModel;

        [Fact]
        public void ShouldMap()
        {
            SetUp();

            var assessmentPerformanceLevel = new CreateModelToAssessmentPerformanceLevelMapper().BuildWithPerformanceLevel(_createModel, _assessment, MasteryPerformanceLevelDescriptor);

            assessmentPerformanceLevel.AcademicSubjectDescriptorId.ShouldBe(_assessment.AcademicSubjectDescriptorId);
            assessmentPerformanceLevel.Version.ShouldBe(_assessment.Version);

            assessmentPerformanceLevel.MinimumScore.ShouldBe(_createModel.Mastery.ToString());
            assessmentPerformanceLevel.AssessmentTitle.ShouldBe(_assessment.AssessmentTitle);
            assessmentPerformanceLevel.AssessedGradeLevelDescriptorId.ShouldBe(_assessment.AssessedGradeLevelDescriptorId);
            assessmentPerformanceLevel.AssessmentReportingMethodTypeId.ShouldBe((int) _createAssessmentModel.ReportingMethod);
            assessmentPerformanceLevel.PerformanceLevelDescriptorId.ShouldBe((int) MasteryPerformanceLevelDescriptor);

            _assessment.AssessmentPerformanceLevels.Count.ShouldBe(1);
        }

        private void SetUp()
        {
            _createAssessmentModel = new CreateAssessmentModelBuilder().Build();
            _assessment = new AssessmentBuilder().Build();
            _genericRepositoryStub = Substitute.For<IGenericRepository>();

            var fourthGradeLevelDescriptor = new GradeLevelDescriptor
            {
                GradeLevelDescriptorId = 99,
                GradeLevelTypeId = 100
            };

            _genericRepositoryStub.Get(Arg.Any<GradeLevelTypeDescriptorQuery>())
                                .Returns(fourthGradeLevelDescriptor);
        }
    }
}

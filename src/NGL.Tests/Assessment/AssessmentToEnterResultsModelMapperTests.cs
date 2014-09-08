using System;
using System.Linq;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Dates;
using NGL.Web.Infrastructure.Azure;
using NGL.Web.Models;
using NGL.Web.Models.Assessment;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Assessment
{
    public class AssessmentToEnterResultsModelMapperTests
    {
        private AssessmentSection _assessmentSection;
        private Web.Data.Entities.Section _section;
        private Web.Data.Entities.Assessment _entity;
        private AssessmentToEnterResultsModelMapper _mapper;
        private ProfilePhotoUrlFetcher _profilePhotoUrlFetcher;

        [Fact]
        public void ShouldMapAssessmentToEnterResultsModel()
        {
            Setup();

            var model = _mapper.Build(_entity);

            model.StudentResults.Count.ShouldBe(_entity.AssessmentSections.First().Section.StudentSectionAssociations.Count(ssa => new DateRange(ssa.BeginDate, ssa.EndDate.GetValueOrDefault()).Includes(_entity.AdministeredDate)));

            model.AssessmentId.ShouldBe(_entity.AssessmentIdentity);
            model.Session.ShouldBe(_assessmentSection.Section.Session.SessionName);
            model.Section.ShouldBe(_assessmentSection.Section.UniqueSectionCode);
            model.AssessmentTitle.ShouldBe(_entity.AssessmentTitle);
            model.CCSS.ShouldBe(_entity.AssessmentLearningStandards.First().LearningStandard.Description);
            model.AssessmentDate.ShouldBe(_entity.AdministeredDate.ToShortDateString());
        }

        [Fact]
        public void ShouldNotFailWhenNoStudentAssessmentsExist()
        {
            Setup();
            _assessmentSection.Section.StudentSectionAssociations.Select(s => s.Student).First().StudentAssessments = null;

            var model = _mapper.Build(_entity);

            model.StudentResults.Count.ShouldBe(_entity.AssessmentSections.First().Section.StudentSectionAssociations.Count(ssa => new DateRange(ssa.BeginDate, ssa.EndDate.GetValueOrDefault()).Includes(_entity.AdministeredDate)));

            model.AssessmentId.ShouldBe(_entity.AssessmentIdentity);
            model.Session.ShouldBe(_assessmentSection.Section.Session.SessionName);
            model.Section.ShouldBe(_assessmentSection.Section.UniqueSectionCode);
            model.AssessmentTitle.ShouldBe(_entity.AssessmentTitle);
            model.CCSS.ShouldBe(_entity.AssessmentLearningStandards.First().LearningStandard.Description);
            model.AssessmentDate.ShouldBe(_entity.AdministeredDate.ToShortDateString());
        }

        [Fact]
        public void ShouldNotAddStudentsWhoWereNotInSectionForAssessmentDate()
        {
            Setup();
            _section.StudentSectionAssociations.First().BeginDate = new DateTime(2014, 9, 10);
            _section.StudentSectionAssociations.First().EndDate = new DateTime(2014, 10, 10);

            var model = _mapper.Build(_entity);

            model.StudentResults.Count.ShouldBe(_entity.AssessmentSections.First().Section.StudentSectionAssociations.Count(ssa => new DateRange(ssa.BeginDate, ssa.EndDate.GetValueOrDefault()).Includes(_entity.AdministeredDate)));

            model.AssessmentId.ShouldBe(_entity.AssessmentIdentity);
            model.Session.ShouldBe(_assessmentSection.Section.Session.SessionName);
            model.Section.ShouldBe(_assessmentSection.Section.UniqueSectionCode);
            model.AssessmentTitle.ShouldBe(_entity.AssessmentTitle);
            model.CCSS.ShouldBe(_entity.AssessmentLearningStandards.First().LearningStandard.Description);
            model.AssessmentDate.ShouldBe(_entity.AdministeredDate.ToShortDateString());
        }

        private void Setup()
        {
            var studentAssessmentToEnterResultsStudentModelMapper =
                Substitute.For<IMapper<StudentAssessment, EnterResultsStudentModel>>();
            studentAssessmentToEnterResultsStudentModelMapper.Build(Arg.Any<StudentAssessment>())
                .Returns(new EnterResultsStudentModel());

            var downloader = Substitute.For<IFileDownloader>();
            _profilePhotoUrlFetcher = Substitute.For<ProfilePhotoUrlFetcher>(downloader);
            _mapper = new AssessmentToEnterResultsModelMapper(studentAssessmentToEnterResultsStudentModelMapper, _profilePhotoUrlFetcher);

            _profilePhotoUrlFetcher.GetProfilePhotoThumbnailUrlOrDefault(Arg.Any<Int32>()).Returns("/Assets/Images/placeholder.png");

            _entity = new AssessmentBuilder()
                .WithAssessmentLearningStandards()
                .WithAssessmentPerformanceLevels()
                .Build();

            Web.Data.Entities.Student student1 = new StudentBuilder().Build();
            Web.Data.Entities.Student student2 = new StudentBuilder().Build();

            _section = new SectionBuilder().WithStudent(student1).WithStudent(student2).WithAssessment(_entity).Build();
            _assessmentSection = _section.AssessmentSections.First();
        }
    }
}

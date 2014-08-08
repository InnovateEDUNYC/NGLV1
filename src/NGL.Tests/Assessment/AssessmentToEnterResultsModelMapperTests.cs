using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
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
        private Web.Data.Entities.Assessment _entity;
        private AssessmentToEnterResultsModelMapper _mapper;

        [Fact]
        public void ShouldMapAssessmentToEnterResultsModel()
        {
            _mapper = Setup(out _assessmentSection, out _entity);

            var model = _mapper.Build(_entity);

            model.StudentResults.Count.ShouldBe(2);
            model.AssessmentId.ShouldBe(_entity.AssessmentIdentity);
            model.Session.ShouldBe(_assessmentSection.Section.Session.SessionName);
            model.Section.ShouldBe(_assessmentSection.Section.UniqueSectionCode);
            model.AssessmentTitle.ShouldBe(_entity.AssessmentTitle);
        }

        [Fact]
        public void ShouldHandleWhenNoStudentAssessmentsExists()
        {
            _mapper = Setup(out _assessmentSection, out _entity);
            _assessmentSection.Section.StudentSectionAssociations.Select(s => s.Student).First().StudentAssessments = null;

            var model = _mapper.Build(_entity);

            model.StudentResults.Count.ShouldBe(2);
            model.AssessmentId.ShouldBe(_entity.AssessmentIdentity);
            model.Session.ShouldBe(_assessmentSection.Section.Session.SessionName);
            model.Section.ShouldBe(_assessmentSection.Section.UniqueSectionCode);
            model.AssessmentTitle.ShouldBe(_entity.AssessmentTitle);
        }

        private static AssessmentToEnterResultsModelMapper Setup(out AssessmentSection assessmentSection, out Web.Data.Entities.Assessment entity)
        {
            var studentAssessmentToEnterResultsStudentModelMapper =
                Substitute.For<IMapper<StudentAssessment, EnterResultsStudentModel>>();
            studentAssessmentToEnterResultsStudentModelMapper.Build(Arg.Any<StudentAssessment>())
                .Returns(new EnterResultsStudentModel());

            var mapper = new AssessmentToEnterResultsModelMapper(studentAssessmentToEnterResultsStudentModelMapper);
            var assessmentSections = new List<AssessmentSection>();
            entity = new Web.Data.Entities.Assessment
            {
                AssessmentIdentity = 1,
                AssessmentTitle = "My Assessment",
                AcademicSubjectDescriptorId = 1,
                AssessedGradeLevelDescriptorId = 1,
                Version = 1,
                AssessmentSections = assessmentSections
            };
            
            var studentSectionAssociations = new List<StudentSectionAssociation>
            {
                new StudentSectionAssociation
                {
                    Student = new StudentBuilder().WithStudentAssessments(new List<StudentAssessment>()
                    {
                        new StudentAssessmentBuilder().WithAssessment(entity).Build()
                    }).Build()
                },
                new StudentSectionAssociation
                {
                    Student = new StudentBuilder().WithStudentAssessments(new List<StudentAssessment>()
                    {
                        new StudentAssessmentBuilder().WithAssessment(entity).Build()
                    }).Build()
                }
            };
            
            assessmentSection = new AssessmentSection()
            {
                Section = new Web.Data.Entities.Section()
                {
                    UniqueSectionCode = "section name",
                    StudentSectionAssociations = studentSectionAssociations,
                    Session = new Web.Data.Entities.Session()
                    {
                        SessionName = "session name"
                    }
                }
            };
            assessmentSections.Add(assessmentSection);


            
            return mapper;
        }
    }
}

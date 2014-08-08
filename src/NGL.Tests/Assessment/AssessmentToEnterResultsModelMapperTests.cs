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
        [Fact]
        public void ShouldMapAssessmentToEnterResultsModel()
        {
            var studentToEnterResultsStudentModelMapper =
                Substitute.For<IMapper<Web.Data.Entities.Student, EnterResultsStudentModel>>();
            studentToEnterResultsStudentModelMapper.Build(Arg.Any<Web.Data.Entities.Student>()).Returns(new EnterResultsStudentModel());

            var mapper = new AssessmentToEnterResultsModelMapper(studentToEnterResultsStudentModelMapper);
            var studentSectionAssociations = new List<StudentSectionAssociation>
            {
                new StudentSectionAssociation(),
                new StudentSectionAssociation()
            };
            var assessmentSections = new List<AssessmentSection>();
            var assessmentSection = new AssessmentSection()
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
            

            var entity = new Web.Data.Entities.Assessment
            {
                AssessmentIdentity = 1,
                AssessmentTitle = "My Assessment",
                AcademicSubjectDescriptorId = 1,
                AssessedGradeLevelDescriptorId = 1,
                Version = 1,
                AssessmentSections = assessmentSections
            };

            var model = mapper.Build(entity);

            model.Students.Count.ShouldBe(2);
            model.AssessmentId.ShouldBe(entity.AssessmentIdentity);
            model.Session.ShouldBe(assessmentSection.Section.Session.SessionName);
            model.Section.ShouldBe(assessmentSection.Section.UniqueSectionCode);
            model.AssessmentTitle.ShouldBe(entity.AssessmentTitle);
        }
    }
}

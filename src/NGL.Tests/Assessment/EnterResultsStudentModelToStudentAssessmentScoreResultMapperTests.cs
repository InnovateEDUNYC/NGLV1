using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Models;
using NGL.Web.Models.Assessment;
using Shouldly;
using Xunit;

namespace NGL.Tests.Assessment
{
    public class EnterResultsStudentModelToStudentAssessmentScoreResultMapperTests
    {

        [Fact]
        public void ShouldEnterResultsStudentModelToStudentAssessmentScoreResult()
        {
            var mapper = new EnterResultsStudentModelToStudentAssessmentScoreResultMapper();

            var model = new EnterResultsStudentModelBuilder().Build();
            var assessment = new Web.Data.Entities.Assessment();

            var entity = mapper.Build(model, assessment);

            entity.StudentUSI.ShouldBe(model.StudentUsi);
            entity.Result.ShouldBe(model.AssessmentResult.ToString());
            
            entity.AssessmentTitle.ShouldBe(assessment.AssessmentTitle);
            entity.AcademicSubjectDescriptorId.ShouldBe(assessment.AcademicSubjectDescriptorId);
            entity.AssessedGradeLevelDescriptorId.ShouldBe(assessment.AssessedGradeLevelDescriptorId);
            entity.Version.ShouldBe(assessment.Version);
            entity.AdministrationDate.ShouldBe(assessment.AdministeredDate);
            entity.AssessmentReportingMethodTypeId.ShouldBe((int)AssessmentReportingMethodTypeEnum.Percentile);
        }
    }
}

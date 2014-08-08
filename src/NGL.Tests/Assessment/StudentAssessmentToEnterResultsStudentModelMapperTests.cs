using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Assessment;
using Shouldly;
using Xunit;

namespace NGL.Tests.Assessment
{
    public class StudentAssessmentToEnterResultsStudentModelMapperTests
    {
        [Fact]
        public void ShouldMapStudentAssessmentToEnterResultsStudentModel()
        {
            var mapper = new StudentAssessmentToEnterResultsStudentModelMapper();
            var entity = new StudentAssessmentBuilder().WithStudent(new Web.Data.Entities.Student()).Build();
            
            var model = mapper.Build(entity);

            model.StudentUsi.ShouldBe(entity.Student.StudentUSI);
            model.Name.ShouldBe(entity.Student.FirstName + " " + entity.Student.LastSurname);
            model.AssessmentResult.ShouldBe(entity.StudentAssessmentScoreResults.First().Result);
        }

        [Fact]
        public void ShouldHandleWhenStudentAssessmentScoreResultsDontExist()
        {
            var mapper = new StudentAssessmentToEnterResultsStudentModelMapper();
            var entity = new StudentAssessmentBuilder().WithStudent(new Web.Data.Entities.Student()).Build();
            entity.StudentAssessmentScoreResults = null;

            var model = mapper.Build(entity);

            model.AssessmentResult = null;
        }
    }
}

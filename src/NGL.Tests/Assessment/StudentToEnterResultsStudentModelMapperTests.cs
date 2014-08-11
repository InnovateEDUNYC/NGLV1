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
    public class StudentToEnterResultsStudentModelMapperTests
    {
        [Fact]
        public void ShouldMapStudentToEnterResultsStudentModel()
        {
            var mapper = new StudentToEnterResultsStudentModelMapper();
            var entity = new StudentBuilder().Build();
            var model = new EnterResultsStudentModel();

            mapper.Map(entity, model);

            model.StudentUsi.ShouldBe(entity.StudentUSI);
            model.Name.ShouldBe(entity.FirstName + " " + entity.LastSurname);
        }
    }
}

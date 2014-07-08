using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Student;
using Shouldly;
using Xunit;

namespace NGL.Tests.Student
{
    public class StudentToProfileModelMapperTest
    {
        [Fact]
        public void shouldMap()
        {
            NGL.Web.Data.Entities.Student student = new NGL.Web.Data.Entities.Student()
            {
                StudentUSI = 1789,
                FirstName = "Bob",
                LastSurname = "Jenkins",
                BirthDate = new DateTime(2000, 2, 2),
                OldEthnicityTypeId = 3,
                HispanicLatinoEthnicity = true,
                SexTypeId = 2
            };
            ProfileModel studentDetailsModel = new ProfileModel();

            StudentToProfileModelMapper mapper = new StudentToProfileModelMapper();
            mapper.Map(student, studentDetailsModel);

            studentDetailsModel.FirstName.ShouldBe("Bob");
            studentDetailsModel.LastSurname.ShouldBe("Jenkins");
            studentDetailsModel.BirthDate.ShouldBe(new DateTime(2000, 2, 2));
            studentDetailsModel.Race.ShouldBe("Black, Not Of Hispanic Origin");
            studentDetailsModel.HispanicLatinoEthnicity.ShouldBe(true);
            studentDetailsModel.Sex.ShouldBe("Male");
        }
    }
}

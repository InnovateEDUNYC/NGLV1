using NGL.Web.Models.Account;
using Shouldly;
using Xunit;

namespace NGL.Tests.Account
{
    public class AddUserModelToStaffMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var mapper = new AddUserModelToStaffMapper();
            
            var staff = mapper.Build(new AddUserModel{Username = "asmith", FirstName = "Adam", LastName = "Smith", StaffUSI = 123, HispanicLatino = true});
            
            staff.LoginId.ShouldBe("asmith");
            staff.FirstName.ShouldBe("Adam");
            staff.LastSurname.ShouldBe("Smith");
            staff.StaffUSI.ShouldBe(123);
            staff.HispanicLatinoEthnicity.ShouldBe(true);
        }
    }
}

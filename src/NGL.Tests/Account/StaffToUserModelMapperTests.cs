using NGL.Tests.Builders;
using NGL.Web.Models.Account;
using Shouldly;
using Xunit;

namespace NGL.Tests.Account
{
    public class StaffToUserModelMapperTests
    {
        [Fact]
        public void WhenRoleExists()
        {
            var mapper = new StaffToUserModelMapper();
            var staff = new StaffBuilder().WithUser("username", "role").Build();
            var userModel = mapper.Build(staff);
            userModel.Username.ShouldBe("username");
            userModel.Role.ShouldBe("role");
            userModel.FirstName.ShouldBe(StaffBuilder.FirstName);
            userModel.LastName.ShouldBe(StaffBuilder.LastName);
            userModel.HispanicLatino.ShouldBe(StaffBuilder.HispanicLatino);
            userModel.StaffUSI.ShouldBe(StaffBuilder.StaffUSI);
        }

        [Fact]
        public void WhenRoleDoesntExist()
        {
            var mapper = new StaffToUserModelMapper();
            var staff = new StaffBuilder().WithUser("username").Build();
            var userModel = mapper.Build(staff);
            userModel.Username.ShouldBe("username");
            userModel.Role.ShouldBe("(role not set)");
            userModel.HispanicLatino.ShouldBe(StaffBuilder.HispanicLatino);
            userModel.StaffUSI.ShouldBe(StaffBuilder.StaffUSI);
        }
    }
}

using NGL.Web.Data.Entities;
using NGL.Web.Models.Account;
using Shouldly;
using Xunit;

namespace NGL.Tests.Account
{
    public class AspNetUserToUserModelMapperTests
    {
        [Fact]
        public void WhenRoleExists()
        {
            var mapper = new AspNetUserToUserModelMapper();
            var userModel = mapper.Build(new AspNetUser {UserName = "username", AspNetRoles = new[] {new AspNetRole {Name = "role"}}});
            userModel.Username.ShouldBe("username");
            userModel.Role.ShouldBe("role");
        }

        [Fact]
        public void WhenRoleDoesntExist()
        {
            var mapper = new AspNetUserToUserModelMapper();
            var userModel = mapper.Build(new AspNetUser {UserName = "username", AspNetRoles = new AspNetRole[0]});
            userModel.Username.ShouldBe("username");
            userModel.Role.ShouldBe("(role not set)");
        }
    }
}

using NGL.Tests.Builders;
using NGL.Web.Models.Account;
using Shouldly;
using Xunit;

namespace NGL.Tests.Account
{
    public class AddUserModelToApplicationUserMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var model = new AddUserModelBuilder().Build();
            var applicationUser = new AddUserModelToApplicationUserMapper().Build(model);

            applicationUser.UserName.ShouldBe(model.Username);
            applicationUser.StaffUSI.ShouldBe(model.StaffUSI.Value);
            applicationUser.Email.ShouldBe(model.PersonalEmail);
        }
    }
}

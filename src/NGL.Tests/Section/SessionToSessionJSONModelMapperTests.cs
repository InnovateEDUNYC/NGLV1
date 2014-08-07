using NGL.Tests.Session;
using NGL.Web.Models.Section;
using Shouldly;
using Xunit;

namespace NGL.Tests.Section
{
    public class SessionToSessionJsonModelMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var entity = new SessionBuilder().Build();
            var mapper = new SessionToSessionJsonModelMapper();

            var model = mapper.Build(entity);

            model.SessionId.ShouldBe(entity.SessionIdentity);
            model.SessionName.ShouldBe(entity.SessionName);
        }
    }
}

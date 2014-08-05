using NGL.Tests.Session;
using NGL.Web.Models;
using NGL.Web.Models.Schedule;
using Shouldly;
using Xunit;

namespace NGL.Tests.Schedule
{
    public class SessionToSessionListItemModelMapperTests
    {
        private IMapper<Web.Data.Entities.Session, SessionListItemModel> _mapper;

        [Fact]
        public void ShouldMapSessionToSessionListItemModel()
        {
            var session = new SessionBuilder().Build();
            _mapper = new SessionToSessionListItemModelMapper();
            var sessionListItemModel = _mapper.Build(session);

            sessionListItemModel.BeginDate.ShouldBe(session.BeginDate);
            sessionListItemModel.EndDate.ShouldBe(session.EndDate);
            sessionListItemModel.SessionId.ShouldBe(session.SessionIdentity);
            sessionListItemModel.SessionName.ShouldBe(session.SessionName);
        }
    }
}

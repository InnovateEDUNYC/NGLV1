using System;
using System.Collections;
using System.Collections.Generic;
using NGL.Web.Data.Filters;
using NGL.Web.Data.Infrastructure;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Data.Filters
{
    public class SessionFiltersTests
    {
        private IGenericRepository _genericRepository;
        private SessionFilter _filter;
        private NGL.Web.Data.Entities.Session _summer2010;
        private Web.Data.Entities.Session _fall2010;

        private void SetUp()
        {
            SetUpGenericRepositoryStub();
            _filter = new SessionFilter(_genericRepository);
        }

        private void SetUpGenericRepositoryStub()
        {
            _genericRepository = Substitute.For<IGenericRepository>();
            _summer2010 = new Web.Data.Entities.Session
            {
                SessionName = "Summer 2010",
                BeginDate = new DateTime(2010, 6, 1),
                EndDate = new DateTime(2010, 8, 30)
            };

            _fall2010 = new Web.Data.Entities.Session
            {
                SessionName = "Fall 2010",
                BeginDate = new DateTime(2010, 9, 1),
                EndDate = new DateTime(2011, 1, 3)
            };

            IEnumerable<Web.Data.Entities.Session> sessionList = new List<Web.Data.Entities.Session>
            {
                _summer2010,
                _fall2010
            };

            _genericRepository.GetAll<Web.Data.Entities.Session>().Returns(sessionList);
        }

        [Fact]
        public void ShouldGiveTheSessionThatIncludesTheGivenDate()
        {
            SetUp();
            var actualSession = _filter.FindSession(new DateTime(2010, 07, 07));
            actualSession.SessionName.ShouldBe(_summer2010.SessionName);
        }
    }
}

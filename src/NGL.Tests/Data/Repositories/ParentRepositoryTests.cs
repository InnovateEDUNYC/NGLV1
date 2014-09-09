using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Moq;
using NGL.Tests.Builders;
using NGL.Web.Data;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Repositories;
using Xunit;

namespace NGL.Tests.Data.Repositories
{
    public class ParentRepositoryTests
    {
        [Fact]
        public void GetByUSIShouldReturnFirstMatchingParentWithDependencies()
        {
            var mockDbContext = new Mock<INglDbContext>();
            var repo = new ParentRepository(mockDbContext.Object);
            const int parentUSI = 3;
            var parentBuilder = new ParentBuilder();
            var parents = new List<Parent> { parentBuilder.WithUSI(1).Build(), parentBuilder.WithUSI(parentUSI).Build(), parentBuilder.WithUSI(2).Build() }.AsQueryable();
            var mockSet = new Mock<IDbSet<Parent>>();
            mockSet.As<IQueryable<Parent>>().Setup(m => m.Provider).Returns(parents.Provider);
            mockSet.As<IQueryable<Parent>>().Setup(m => m.Expression).Returns(parents.Expression);
            mockDbContext.Setup(dbContext => dbContext.Set<Parent>()).Returns(mockSet.Object);

            var returnedParent = repo.GetByUSI(parentUSI);

            Assert.Equal(parentUSI, returnedParent.ParentUSI);
        }
    }
}

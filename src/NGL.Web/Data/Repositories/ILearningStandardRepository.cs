using System.Collections.Generic;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models.Assessment;

namespace NGL.Web.Data.Repositories
{
    public interface ILearningStandardRepository : IRepositoryBase
    {
        List<CommonCoreStandardListItemModel> GetCommonCoreStandards();
    }
}
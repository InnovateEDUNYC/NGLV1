using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Assessment
{
    public class LearningStandardToCommonCoreStandardListItemModelMapper : MapperBase<LearningStandard, CommonCoreStandardListItemModel>
    {
        public override void Map(LearningStandard source, CommonCoreStandardListItemModel target)
        {
            target.LearningStandardId = source.LearningStandardId;
            target.Description = source.Description;
        }
    }
}
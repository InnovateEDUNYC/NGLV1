namespace NGL.Web.Models.Section
{
    public class ClassPeriodToClassPeriodListItemModelMapper : MapperBase<Data.Entities.ClassPeriod, ClassPeriodListItemModel>
    {
        public override void Map(Data.Entities.ClassPeriod source, ClassPeriodListItemModel target)
        {
            target.ClassPeriodName = source.ClassPeriodName;
        }
    }
}
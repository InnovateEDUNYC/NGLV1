namespace NGL.Web.Models.ClassPeriod
{
    public class ClassPeriodToIndexModelMapper : MapperBase<Data.Entities.ClassPeriod, IndexModel>
    {
        public override void Map(Data.Entities.ClassPeriod source, IndexModel target)
        {
            target.ClassPeriodName = source.ClassPeriodName;
        }
    }
}
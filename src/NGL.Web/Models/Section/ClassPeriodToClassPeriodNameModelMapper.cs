namespace NGL.Web.Models.Section
{
    public class ClassPeriodToClassPeriodNameModelMapper : MapperBase<Data.Entities.ClassPeriod, ClassPeriodNameModel>
    {
        public override void Map(Data.Entities.ClassPeriod source, ClassPeriodNameModel target)
        {
            target.ClassPeriodName = source.ClassPeriodName;
        }
    }
}
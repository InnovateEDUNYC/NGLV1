namespace NGL.Web.Models.Section
{
    public class LocationToLocationListItemModelMapper : MapperBase<Data.Entities.Location, LocationListItemModel>
    {
        public override void Map(Data.Entities.Location source, LocationListItemModel target)
        {
            target.Classroom = source.ClassroomIdentificationCode;
        }
    }
}
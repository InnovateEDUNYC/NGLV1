namespace NGL.Web.Models.Location
{
    public class LocationToIndexModelMapper : MapperBase<Data.Entities.Location, IndexModel>
    {
        public override void Map(Data.Entities.Location source, IndexModel target)
        {
            target.ClassroomIdentificationCode = source.ClassroomIdentificationCode;
            target.MaximumNumberOfSeats = source.MaximumNumberOfSeats;
            target.OptimalNumberOfSeats = source.OptimalNumberOfSeats;
        }
    }
}
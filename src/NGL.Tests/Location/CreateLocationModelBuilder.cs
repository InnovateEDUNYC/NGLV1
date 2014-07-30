using NGL.Web.Models.Location;

namespace NGL.Tests.Location
{
    public class CreateLocationModelBuilder
    {
        private const string ClassRoomIdentificationCode = "A101";
        private const int MaximumNumberOfSeats = 40;
        private const int OptimalNumberOfSeats = 30;

        public CreateModel Build()
        {
            return new CreateModel
            {
                ClassroomIdentificationCode = ClassRoomIdentificationCode,
                MaximumNumberOfSeats = MaximumNumberOfSeats,
                OptimalNumberOfSeats = OptimalNumberOfSeats
            };
        }

    }
}

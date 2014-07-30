namespace NGL.Tests.Builders
{
    class LocationBuilder
    {
        private const string ClassroomIdentificationCode = "Gym";

        public Web.Data.Entities.Location Build()
        {
            return new Web.Data.Entities.Location
            {
                SchoolId = Constants.SchoolId,
                ClassroomIdentificationCode = ClassroomIdentificationCode
            };
        }
    }
}

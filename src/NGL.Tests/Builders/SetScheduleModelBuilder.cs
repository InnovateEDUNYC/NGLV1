
using System;
using NGL.Web.Models.Schedule;

namespace NGL.Tests.Builders
{
    public class SetScheduleModelBuilder
    {
        public SetModel Build()
        {
         return new SetModel
         {
             BeginDate = new DateTime(2004, 2, 2),
             EndDate = new DateTime(2004, 8, 8),
             StudentName = "Jack Conway",
             ProfilePhotoUrl = "example.com",
             StudentUsi = 443,
             SectionId = 12
         };
        }
    }
}

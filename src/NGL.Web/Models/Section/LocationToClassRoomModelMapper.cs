using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGL.Web.Models.Section;

namespace NGL.Web.Models.Section
{
    public class LocationToClassRoomModelMapper : MapperBase<Data.Entities.Location, ClassRoomModel>
    {
        public override void Map(Data.Entities.Location source, ClassRoomModel target)
        {
            target.ClassRoom = source.ClassroomIdentificationCode;
        }
    }
}
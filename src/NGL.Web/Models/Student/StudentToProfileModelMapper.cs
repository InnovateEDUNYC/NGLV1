using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Humanizer;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class StudentToProfileModelMapper : IMapper<NGL.Web.Data.Entities.Student, ProfileModel>
    {
        public void Map(Data.Entities.Student source, ProfileModel target)
        {
            target.FirstName = source.FirstName;
            target.LastSurname = source.LastSurname;
            target.BirthDate = source.BirthDate;
            target.Race = ((OldEthnicityTypeEnum) source.OldEthnicityTypeId).Humanize();
            target.HispanicLatinoEthnicity = source.HispanicLatinoEthnicity;
            target.Sex = ((SexTypeEnum)source.SexTypeId).Humanize();
        }
    }
}
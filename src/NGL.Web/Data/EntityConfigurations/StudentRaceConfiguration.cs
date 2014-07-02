using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;

namespace NGL.Web.Data.EntityConfigurations
{
    public class StudentRaceConfiguration : EntityTypeConfiguration<StudentRace>
    {
       public StudentRaceConfiguration()
        {
            HasKey(u => new {u.StudentUSI, u.RaceTypeId });
        }
    }
}
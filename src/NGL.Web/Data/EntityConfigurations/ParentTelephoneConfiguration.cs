using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;

namespace NGL.Web.Data.EntityConfigurations
{
    public class ParentTelephoneConfiguration : EntityTypeConfiguration<ParentTelephone>
    {
        public ParentTelephoneConfiguration()
        {
            HasKey(u => new {u.ParentUSI, u.TelephoneNumberTypeId });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;

namespace NGL.Web.Data.EntityConfigurations
{
    public class ParentAddressConfiguration : EntityTypeConfiguration<ParentAddress>
    {
        public ParentAddressConfiguration()
        {
            HasKey(u => new {u.ParentUSI, u.AddressTypeId });
        }
    }
}
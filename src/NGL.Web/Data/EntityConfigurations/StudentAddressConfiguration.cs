using System.Data.Entity.ModelConfiguration;
using NGL.Web.Data.Entities;

namespace NGL.Web.Data.EntityConfigurations
{
    public class StudentAddressConfiguration :EntityTypeConfiguration<StudentAddress>
    {
        public StudentAddressConfiguration()
        {
            HasKey(u => new {u.StudentUSI, u.AddressTypeId});
        }
    
    }
}
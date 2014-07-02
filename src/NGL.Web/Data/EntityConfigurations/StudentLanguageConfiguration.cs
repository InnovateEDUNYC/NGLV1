using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;

namespace NGL.Web.Data.EntityConfigurations
{
    public class StudentLanguageConfiguration : EntityTypeConfiguration<StudentLanguage>
    {
       public StudentLanguageConfiguration()
        {
            HasKey(u => new {u.StudentUSI, u.LanguageDescriptorId});
        }
    }
}
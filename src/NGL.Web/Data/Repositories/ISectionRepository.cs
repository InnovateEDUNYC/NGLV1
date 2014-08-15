using System;
using NGL.Web.Data.Entities;

namespace NGL.Web.Data.Repositories
{
    public interface ISectionRepository
    {
        Section GetWithStudentAssociationsForDate(int sectionIdentity, DateTime dateTime);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Section
{
    public class StudentSectionAssociationToSectionListItemModelMapper : MapperBase<StudentSectionAssociation, SectionListItemModel>
    {
        public override void Map(StudentSectionAssociation source, SectionListItemModel target)
        {
            target.Name = source.LocalCourseCode;
            target.BeginDate = source.BeginDate.ToString("dd.MM.yyyy");
            if (source.EndDate != null) 
                target.EndDate = ((DateTime)source.EndDate).ToString("dd.MM.yyyy");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGL.Web.Models.Section
{
    public class SectionToAutocompleteModelMapper : MapperBase<Data.Entities.Section, AutocompleteModel>
    {
        public override void Map(Data.Entities.Section source, AutocompleteModel target)
        {
            target.Id = source.SectionIdentity;

            target.LabelName = source.UniqueSectionCode + " (" + 
                source.LocalCourseCode + ", " + 
                source.ClassPeriodName + ")";

            target.ValueName = source.UniqueSectionCode + " (" + 
                source.LocalCourseCode + ", " + 
                source.ClassPeriodName + ")";
        }
    }
}
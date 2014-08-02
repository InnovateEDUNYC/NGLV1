using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NGL.Web.Models.Section
{
    public class SectionListItemModel
    {
        public string Name { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
    }
}
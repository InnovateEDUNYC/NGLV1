using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGL.Web.Models.Assessment
{
    public class IndexModel
    {
        public string CCSS { get; set; }
        public int id { get; set; }
        public string AssessmentTitle { get; set; }
        public string SectionName { get; set; }
        public string SessionName { get; set; }
        public string Date { get; set; }
    }
}
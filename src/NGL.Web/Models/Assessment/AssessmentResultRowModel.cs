using System;
using System.Collections.Generic;

namespace NGL.Web.Models.Assessment
{
    public class AssessmentResultRowModel
    {
        public string CommonCoreStandard { get; set; }
        public string SectionCode { get; set; }
        public DateTime Date { get; set; }
        public string Grade { get; set; }
        public string AssessmentTypeDescription { get; set; }
        public string AssessmentTitle { get; set; }
        public IList<string> Results { get; set; }
    }
}
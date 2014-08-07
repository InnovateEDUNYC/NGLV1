using System.Collections.Generic;

namespace NGL.Web.Models.Assessment
{
    public class AssessmentResultRowModel
    {
        public string CommonCoreStandard { get; set; }
        public IList<string> Results { get; set; }
    }
}
using System.Collections.Generic;

namespace NGL.Web.Models.Assessment
{
    public class AssessmentResultModel
    {
        public int StudentUsi { get; set; }
        public string Session { get; set; }
        public int? SessionId { get; set; }
        public int? DayTo { get; set; }
        public int? DayFrom { get; set; }

        public IList<AssessmentResultRowModel> AssessmentResultRows { get; set; }
    }
}
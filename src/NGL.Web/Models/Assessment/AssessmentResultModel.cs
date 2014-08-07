using System.Collections.Generic;

namespace NGL.Web.Models.Assessment
{
    public class AssessmentResultModel
    {
        public int StudentUsi { get; set; }
        public int? SessionId { get; set; }
        public int? Week { get; set; }

        public IList<AssessmentResultRowModel> AssessmentResultRows { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGL.Web.Models.Assessment
{
    public class EnterResultsModel
    {
        public List<EnterResultsStudentModel> StudentResults { get; set; }
        public int AssessmentId { get; set; }
        public string Session { get; set; }
        public string Section { get; set; }
        public string AssessmentTitle { get; set; }
        public string CCSS { get; set; }
        public string AssessmentDate { get; set; }
    }
}
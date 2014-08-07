using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGL.Web.Models.Assessment
{
    public class EnterResultsStudentModel
    {
        public string Name { get; set; }
        public string StudentUsi { get; set; }
        public decimal AssessmentResult { get; set; }
    }
}
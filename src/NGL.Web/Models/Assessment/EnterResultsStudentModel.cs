using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Assessment
{
    public class EnterResultsStudentModel
    {
        public string Name { get; set; }
        public int StudentUsi { get; set; }
        public string AssessmentResult { get; set; }
        public int AssessmentIdentity { get; set; }
    }
}
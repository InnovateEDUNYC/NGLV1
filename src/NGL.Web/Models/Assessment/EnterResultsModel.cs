using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGL.Web.Models.Assessment
{
    public class EnterResultsModel
    {
        public List<EnterResultsStudentModel> Students { get; set; }
        public string AssessmentTitle { get; set; }

    }

}
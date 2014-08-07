using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Assessment
{
    public class EnterResultsStudentModelToStudentAssessmentMapper : MapperBase<EnterResultsStudentModel, StudentAssessment>
    {
        public override void Map(EnterResultsStudentModel source, StudentAssessment target)
        {
            target.StudentUSI = source.StudentUsi;
        }
    }
}
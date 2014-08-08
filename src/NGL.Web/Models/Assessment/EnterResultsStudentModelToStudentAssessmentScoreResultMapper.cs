using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Assessment
{
    public class EnterResultsStudentModelToStudentAssessmentScoreResultMapper : 
        MapperBase<EnterResultsStudentModel, StudentAssessmentScoreResult>
    {
        public override void Map(EnterResultsStudentModel source, StudentAssessmentScoreResult target)
        {
            target.StudentUSI = source.StudentUsi;
            target.Result = source.AssessmentResult.ToString();
            target.AssessmentReportingMethodTypeId = (int) AssessmentReportingMethodTypeEnum.Percentile;
            target.ResultDatatypeTypeId = (int)ResultDatatypeTypeEnum.Percentile;
        }
    }
}
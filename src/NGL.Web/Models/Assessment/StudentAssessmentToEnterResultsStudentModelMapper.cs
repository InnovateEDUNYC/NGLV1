using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core.Internal;

namespace NGL.Web.Models.Assessment
{
    public class StudentAssessmentToEnterResultsStudentModelMapper : MapperBase<Data.Entities.StudentAssessment, EnterResultsStudentModel>
    {
        public override void Map(Data.Entities.StudentAssessment source, EnterResultsStudentModel target)
        {
            target.StudentUsi = source.Student.StudentUSI;
            target.Name = source.Student.FirstName + " " + source.Student.LastSurname;

            if (!source.StudentAssessmentScoreResults.IsNullOrEmpty())
                target.AssessmentResult = source.StudentAssessmentScoreResults.First().Result;
        }
    }
}
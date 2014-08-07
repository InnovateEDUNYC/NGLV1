using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class StudentAssessmentScoreResultBuilder
    {
        private string _result = "90";

        public StudentAssessmentScoreResult Build()
        {
            return new StudentAssessmentScoreResult
            {
                Result = _result        
            };
        }
    }
}
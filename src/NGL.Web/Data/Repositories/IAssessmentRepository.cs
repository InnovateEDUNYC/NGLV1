using System;
using System.Collections.Generic;
using NGL.Web.Data.Entities;

namespace NGL.Web.Data.Repositories
{
    public interface IAssessmentRepository
    {
        IEnumerable<StudentAssessment> GetAssessmentResults(int studentUsi, DateTime startDate, DateTime endDate);
    }
}

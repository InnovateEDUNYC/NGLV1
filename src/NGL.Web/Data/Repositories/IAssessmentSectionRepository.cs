using System.Collections.Generic;
using NGL.Web.Data.Entities;

namespace NGL.Web.Data.Repositories
{
    public interface IAssessmentSectionRepository
    {
        IEnumerable<AssessmentSection> GetByStudentSectionAssociation(StudentSectionAssociation studentSectionAssociation);
    }
}

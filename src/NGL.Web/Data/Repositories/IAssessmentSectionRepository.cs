using System.Collections.Generic;
using NGL.Web.Data.Entities;

namespace NGL.Web.Data.Repositories
{
    public interface IAssessmentSectionRepository
    {
        List<AssessmentSection> GetByStudentSectionAssociation(StudentSectionAssociation studentSectionAssociation);
    }
}

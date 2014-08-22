using NGL.Web.Data.Entities;

namespace NGL.Web.Infrastructure.Security
{
    public class ResourceService : IResourceService
    {
        public string GetResourcesFor(ApplicationRole role)
        {
            switch (role)
            {
                case ApplicationRole.MasterAdmin:
                    return "session.create session.edit session.view"
                           + " schoolInfo.create schoolInfo.edit schoolInfo.view"
                           + " enrollment.create enrollment.edit enrollment.view"
                           + " courseGeneration.create courseGeneration.edit courseGeneration.view"
                           + " user.create user.edit user.view"
                           + " scheduleStudents.create scheduleStudents.edit scheduleStudents.view"
                           + " assessment.create assessment.edit assessment.view"
                           + " attendance.create attendance.edit attendance.view attendance.clearAllFlags";

                case ApplicationRole.Admin:
                    return "session.edit session.view"
                           + " schoolInfo.edit schoolInfo.view"
                           + " enrollment.create enrollment.edit enrollment.view"
                           + " courseGeneration.create courseGeneration.edit courseGeneration.view"
                           + " user.create user.edit user.view"
                           + " scheduleStudents.create scheduleStudents.edit scheduleStudents.view"
                           + " assessment.create assessment.edit assessment.view"
                           + " attendance.view";

                case ApplicationRole.Teacher:
                    return "session.view"
                           + " schoolInfo.view"
                           + " enrollment.view"
                           + " courseGeneration.view"
                           + " user.view"
                           + " scheduleStudents.view"
                           + " assessment.create assessment.edit assessment.view"
                           + " attendance.edit attendance.view";

            }

            return string.Empty;
        }
    }
}
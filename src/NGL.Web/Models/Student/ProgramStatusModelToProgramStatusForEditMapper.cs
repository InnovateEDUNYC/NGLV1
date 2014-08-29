using NGL.Web.Controllers;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Enrollment;

namespace NGL.Web.Models.Student
{
    public class ProgramStatusModelToProgramStatusForEditMapper
    {
        public void Map(EnterProgramStatusModel source, StudentProgramStatus target,
            ProgramStatusUploadedFilePaths filePaths)
        {
            target.TestingAccommodation = source.TestingAccommodation.GetValueOrDefault();
            target.BilingualProgram = source.BilingualProgram.GetValueOrDefault();
            target.EnglishAsSecondLanguage = source.EnglishAsSecondLanguage.GetValueOrDefault();
            target.SchoolFoodServicesEligibilityTypeId = (int)source.FoodServicesEligibilityStatus;
            target.Gifted = source.Gifted.GetValueOrDefault();
            target.SpecialEducation = source.SpecialEducation.GetValueOrDefault();
            target.TitleParticipation = source.TitleParticipation.GetValueOrDefault();
            target.McKinneyVento = source.McKinneyVento.GetValueOrDefault();

            target.TitleParticipationFile = filePaths.TitleParticipation ?? NewFilePath(source.TitleParticipation, target.TitleParticipationFile);
            target.TestingAccommodationFile = filePaths.TestingAccomodation ?? NewFilePath(source.TestingAccommodation, target.TestingAccommodationFile);
            target.SpecialEducationFile = filePaths.SpecialEducation ?? NewFilePath(source.SpecialEducation, target.SpecialEducationFile);
            target.McKinneyVentoFile = filePaths.McKinneyVento ?? NewFilePath(source.McKinneyVento.GetValueOrDefault(), target.McKinneyVentoFile);
        }

        private static string NewFilePath(bool? isYesSelectedForField, string file)
        {
            return (isYesSelectedForField.GetValueOrDefault() ? file : null);
        }
    }
}
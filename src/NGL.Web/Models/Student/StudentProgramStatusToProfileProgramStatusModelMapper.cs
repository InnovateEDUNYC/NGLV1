using Humanizer;
using NGL.Web.Data.Entities;
using NGL.Web.Extensions;
using NGL.Web.Infrastructure.Azure;

namespace NGL.Web.Models.Student
{
    public class StudentProgramStatusToProfileProgramStatusModelMapper : MapperBase<StudentProgramStatus, ProfileProgramStatusModel>
    {
        private readonly IFileDownloader _azureFileDownloader;

        public StudentProgramStatusToProfileProgramStatusModelMapper(IFileDownloader azureFileDownloader)
        {
            _azureFileDownloader = azureFileDownloader;
        }

        public override void Map(StudentProgramStatus source, ProfileProgramStatusModel target)
        {
            target.TestingAccommodation = source.TestingAccommodation.ToYesNoString();
            target.BilingualProgram = source.BilingualProgram.ToYesNoString();
            target.EnglishAsSecondLanguage = source.EnglishAsSecondLanguage.ToYesNoString();
            target.Gifted = source.Gifted.ToYesNoString();
            target.SpecialEducation = source.SpecialEducation.ToYesNoString();
            target.TitleParticipation = source.TitleParticipation.ToYesNoString();
            target.McKinneyVento = source.McKinneyVento.ToYesNoString();

            target.FoodServiceEligibilityStatus = ((SchoolFoodServicesEligibilityTypeEnum)source.SchoolFoodServicesEligibilityTypeId).Humanize(LetterCasing.Title);

            target.TestingAccommodationFile = GetFullFilePath(source.TestingAccommodationFile);
            target.SpecialEducationFile = GetFullFilePath(source.SpecialEducationFile);
            target.TitleParticipationFile = GetFullFilePath(source.TitleParticipationFile);
            target.McKinneyVentoFile = GetFullFilePath(source.McKinneyVentoFile);
        }

        private string GetFullFilePath(string partialFilePath)
        {
            return partialFilePath == null ? null : _azureFileDownloader.DownloadPath(ConfigManager.StudentBlobContainer, partialFilePath);
        }
    }
}
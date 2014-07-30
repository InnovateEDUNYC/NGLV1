using Humanizer;
using NGL.Web.Data.Entities;
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
            target.TestingAccommodation = source.TestingAccommodation;
            target.BilingualProgram = source.BilingualProgram;
            target.EnglishAsSecondLanguage = source.EnglishAsSecondLanguage;
            target.Gifted = source.Gifted;
            target.SpecialEducation = source.SpecialEducation;
            target.TitleParticipation = source.TitleParticipation;
            target.McKinneyVento = source.McKinneyVento;

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
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Extensions;
using NGL.Web.Infrastructure.Azure;
using NGL.Web.Models.Student;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Student
{
    public class StudentProgramStatusToProfileProgramStatusModelMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var studentProgramStatus = new StudentProgramStatusBuilder()
                .WithSchoolFoodServicesEligibility(SchoolFoodServicesEligibilityTypeEnum.Fullprice)
                .Build();
            var downloader = Substitute.For<IFileDownloader>();
            downloader.DownloadPath(ConfigManager.StudentBlobContainer, studentProgramStatus.TestingAccommodationFile).Returns("TestingAccommodationFile_Full_Url");
            downloader.DownloadPath(ConfigManager.StudentBlobContainer, studentProgramStatus.SpecialEducationFile).Returns("SpecialEducationFile_Full_Url");

            var model = new StudentProgramStatusToProfileProgramStatusModelMapper(downloader).Build(studentProgramStatus);

            model.TestingAccommodation.ShouldBe(studentProgramStatus.TestingAccommodation.ToYesNoString());
            model.BilingualProgram.ShouldBe(studentProgramStatus.BilingualProgram.ToYesNoString());
            model.EnglishAsSecondLanguage.ShouldBe(studentProgramStatus.EnglishAsSecondLanguage.ToYesNoString());
            model.Gifted.ShouldBe(studentProgramStatus.Gifted.ToYesNoString());
            model.SpecialEducation.ShouldBe(studentProgramStatus.SpecialEducation.ToYesNoString());
            model.TitleParticipation.ShouldBe(studentProgramStatus.TitleParticipation.ToYesNoString());
            model.McKinneyVento.ShouldBe(studentProgramStatus.McKinneyVento.ToYesNoString());

            model.FoodServicesEligibilityStatusForDisplay.ShouldBe("Full Price");

            model.TestingAccommodationFile.ShouldBe("TestingAccommodationFile_Full_Url");
            model.SpecialEducationFile.ShouldBe("SpecialEducationFile_Full_Url");
            model.TitleParticipationFile.ShouldBe(null);
            model.McKinneyVentoFile.ShouldBe(null);
            downloader.DidNotReceive().DownloadPath(ConfigManager.StudentBlobContainer, studentProgramStatus.TitleParticipationFile);
            downloader.DidNotReceive().DownloadPath(ConfigManager.StudentBlobContainer, studentProgramStatus.McKinneyVentoFile);

            downloader.ReceivedCalls();
        }
    }
}

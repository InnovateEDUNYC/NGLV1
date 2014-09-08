using System;
using System.Linq;
using NGL.Tests.Builders;
using NGL.Web.Infrastructure.Azure;
using NGL.Web.Models.Assessment;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Assessment
{
    public class StudentAssessmentToEnterResultsStudentModelMapperTests
    {
        private ProfilePhotoUrlFetcher _profilePhotoUrlFetcher;

        [Fact]
        public void ShouldMapStudentAssessmentToEnterResultsStudentModel()
        {
            Setup();
            var mapper = new StudentAssessmentToEnterResultsStudentModelMapper(_profilePhotoUrlFetcher);
            var entity = new StudentAssessmentBuilder().WithStudent(new Web.Data.Entities.Student()).Build();
            
            var model = mapper.Build(entity);

            model.StudentUsi.ShouldBe(entity.Student.StudentUSI);
            model.Name.ShouldBe(entity.Student.FirstName + " " + entity.Student.LastSurname);
            model.AssessmentResult.ShouldBe(Convert.ToDecimal(entity.StudentAssessmentScoreResults.First().Result));
            model.ProfileThumbnailUrl.ShouldBe("/Assets/Images/placeholder.png");
        }

        [Fact]
        public void ShouldNotFailWhenStudentAssessmentScoreResultsDontExist()
        {
            Setup();
            var mapper = new StudentAssessmentToEnterResultsStudentModelMapper(_profilePhotoUrlFetcher);
            var entity = new StudentAssessmentBuilder().WithStudent(new Web.Data.Entities.Student()).Build();
            entity.StudentAssessmentScoreResults = null;

            var model = mapper.Build(entity);

            model.AssessmentResult = null;
        }

        private void Setup()
        {
            var downloader = Substitute.For<IFileDownloader>();
            _profilePhotoUrlFetcher = Substitute.For<ProfilePhotoUrlFetcher>(downloader);
            _profilePhotoUrlFetcher.GetProfilePhotoThumbnailUrlOrDefault(Arg.Any<Int32>()).Returns("/Assets/Images/placeholder.png");
        }
    }
}

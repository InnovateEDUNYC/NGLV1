using System;
using System.Linq;
using Castle.Core.Internal;
using NGL.Web.Infrastructure.Azure;

namespace NGL.Web.Models.Assessment
{
    public class StudentAssessmentToEnterResultsStudentModelMapper : MapperBase<Data.Entities.StudentAssessment, EnterResultsStudentModel>
    {
        private readonly ProfilePhotoUrlFetcher _profilePhotoUrlFetcher;

        public StudentAssessmentToEnterResultsStudentModelMapper(ProfilePhotoUrlFetcher profilePhotoUrlFetcher)
        {
            _profilePhotoUrlFetcher = profilePhotoUrlFetcher;
        }

        public override void Map(Data.Entities.StudentAssessment source, EnterResultsStudentModel target)
        {
            target.StudentUsi = source.Student.StudentUSI;
            target.Name = source.Student.FirstName + " " + source.Student.LastSurname;
            target.ProfileThumbnailUrl = _profilePhotoUrlFetcher.GetProfilePhotoThumbnailUrlOrDefault(source.StudentUSI);

            if (!source.StudentAssessmentScoreResults.IsNullOrEmpty())
            {
                var result = source.StudentAssessmentScoreResults.First().Result;
                target.AssessmentResult = result == string.Empty? (decimal?) null : Convert.ToDecimal(result);
            }
        }
    }
}
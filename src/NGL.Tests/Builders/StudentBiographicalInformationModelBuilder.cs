using NGL.Web.Data.Entities;
using NGL.Web.Models.Student;

namespace NGL.Tests.Builders
{
    public class StudentBiographicalInformationModelBuilder
    {
        private const int StudentUsi = 3434;
        private const string BirthDate = "6/6/2004";
        private const SexTypeEnum Sex = SexTypeEnum.Male;
        private const bool HispanicLatinoEthnicity = false;
        private const LanguageDescriptorEnum HomeLanguage = LanguageDescriptorEnum.Spanish;
        private const RaceTypeEnum Race = RaceTypeEnum.BlackAfricanAmerican;

        public EditableStudentBiographicalInfoModel Build()
        {
            return new EditableStudentBiographicalInfoModel
            {
                StudentUsi = StudentUsi,
                BirthDate = BirthDate,
                Sex = Sex,
                HispanicLatinoEthnicity = HispanicLatinoEthnicity,
                HomeLanguage = HomeLanguage,
                Race = Race
            };
        }
    }
}
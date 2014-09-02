using NGL.Web.Data.Entities;
using NGL.Web.Models.Student;

namespace NGL.Tests.Builders
{
    public class StudentBiographicalInformationModelBuilder
    {
        private int _studentUsi = 3434;
        private string _birthDate = "6/6/2004";
        private SexTypeEnum _sex = SexTypeEnum.Male;
        private bool _hispanicLatinoEthnicity = false;
        private LanguageDescriptorEnum _homeLanguage = LanguageDescriptorEnum.Spanish;
        private RaceTypeEnum _race = RaceTypeEnum.BlackAfricanAmerican;

        public EditableStudentBiographicalInfoModel Build()
        {
            return new EditableStudentBiographicalInfoModel
            {
                StudentUsi = _studentUsi,
                BirthDate = _birthDate,
                Sex = _sex,
                HispanicLatinoEthnicity = _hispanicLatinoEthnicity,
                HomeLanguage = _homeLanguage,
                Race = _race
            };
        }
    }
}
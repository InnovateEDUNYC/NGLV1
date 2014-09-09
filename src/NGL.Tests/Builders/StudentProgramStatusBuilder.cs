using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class StudentProgramStatusBuilder
    {
        private const bool TestingAccommodation = true;
        private const bool BilingualProgram = false;
        private const bool EnglishAsSecondLanguage = true;
        private int _schoolFoodServicesEligibilityTypeId = (int) SchoolFoodServicesEligibilityTypeEnum.Reducedprice;
        private const bool Gifted = true;
        private const bool SpecialEducation = true;
        private const bool TitleParticipation = false;
        private const bool McKinneyVento = true;
        private const string TestingAccommodationFile = "TestingAccommodationFile";
        private const string SpecialEducationFile = "SpecialEducationFile";
        private readonly string _titleParticipationFile = null;
        private readonly string _mcKinneyVentoFile = null;

        public StudentProgramStatus Build()
        {
            return new StudentProgramStatus
            {
                TestingAccommodation = TestingAccommodation,
                BilingualProgram = BilingualProgram,
                EnglishAsSecondLanguage = EnglishAsSecondLanguage,
                SchoolFoodServicesEligibilityTypeId = _schoolFoodServicesEligibilityTypeId,
                Gifted = Gifted,
                SpecialEducation = SpecialEducation,
                TitleParticipation = TitleParticipation,
                McKinneyVento = McKinneyVento,
                TestingAccommodationFile = TestingAccommodationFile,
                SpecialEducationFile = SpecialEducationFile,
                TitleParticipationFile = _titleParticipationFile,
                McKinneyVentoFile = _mcKinneyVentoFile
            };
        }

        public StudentProgramStatusBuilder WithSchoolFoodServicesEligibility(
            SchoolFoodServicesEligibilityTypeEnum schoolFoodServicesEligibilityType)
        {
            _schoolFoodServicesEligibilityTypeId = (int) schoolFoodServicesEligibilityType;
            return this;
        }
    }
}
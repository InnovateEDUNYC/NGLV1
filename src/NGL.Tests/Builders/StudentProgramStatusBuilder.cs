using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class StudentProgramStatusBuilder
    {
        private bool TestingAccommodation = true;
        private bool BilingualProgram = false;
        private bool EnglishAsSecondLanguage = true;
        private int SchoolFoodServicesEligibilityTypeId = (int) SchoolFoodServicesEligibilityTypeEnum.Reducedprice;
        private bool Gifted = true;
        private bool SpecialEducation = true;
        private bool TitleParticipation = false;
        private bool McKinneyVento = true;
        private string TestingAccommodationFile = "TestingAccommodationFile";
        private string SpecialEducationFile = "SpecialEducationFile";
        private string TitleParticipationFile = null;
        private string McKinneyVentoFile = null;

        public StudentProgramStatus Build()
        {
            return new StudentProgramStatus
            {
                TestingAccommodation = TestingAccommodation,
                BilingualProgram = BilingualProgram,
                EnglishAsSecondLanguage = EnglishAsSecondLanguage,
                SchoolFoodServicesEligibilityTypeId = SchoolFoodServicesEligibilityTypeId,
                Gifted = Gifted,
                SpecialEducation = SpecialEducation,
                TitleParticipation = TitleParticipation,
                McKinneyVento = McKinneyVento,
                TestingAccommodationFile = TestingAccommodationFile,
                SpecialEducationFile = SpecialEducationFile,
                TitleParticipationFile = TitleParticipationFile,
                McKinneyVentoFile = McKinneyVentoFile
            };
        }

        public StudentProgramStatusBuilder WithSchoolFoodServicesEligibility(
            SchoolFoodServicesEligibilityTypeEnum schoolFoodServicesEligibilityType)
        {
            SchoolFoodServicesEligibilityTypeId = (int) schoolFoodServicesEligibilityType;
            return this;
        }
    }
}
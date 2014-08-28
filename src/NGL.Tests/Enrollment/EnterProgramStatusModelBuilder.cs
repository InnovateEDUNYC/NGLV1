using NGL.Web.Data.Entities;
using NGL.Web.Models.Enrollment;

namespace NGL.Tests.Enrollment
{
    public class EnterProgramStatusModelBuilder
    {
        private bool? _testingAccommodation = true;
        private bool? SpecialEducation = true;
        private bool? _mcKinneyVento = false;
        private bool? TitleParticipation = true;
        private bool? BilingualProgram = false;
        private bool? EnglishAsSecondLanguage = true;
        private bool? Gifted = true;
        private const SchoolFoodServicesEligibilityTypeEnum FoodServiceEligibilityStatus = SchoolFoodServicesEligibilityTypeEnum.Fullprice;

        public EnterProgramStatusModel Build()
        {
            return new EnterProgramStatusModel
            {
                TestingAccommodation = _testingAccommodation,
                SpecialEducation = SpecialEducation,
                McKinneyVento = _mcKinneyVento,
                TitleParticipation = TitleParticipation,
                BilingualProgram = BilingualProgram,
                EnglishAsSecondLanguage = EnglishAsSecondLanguage,
                Gifted = Gifted,
                FoodServicesEligibilityStatus = FoodServiceEligibilityStatus,
            };
        }

        public EnterProgramStatusModelBuilder WithTestingAccommodation(bool testingAccommodation)
        {
            _testingAccommodation = testingAccommodation;
            return this;
        }

        public EnterProgramStatusModelBuilder WithMcKinneyVento(bool mcKinneyVento)
        {
            _mcKinneyVento = mcKinneyVento;
            return this;
        }
    }
}

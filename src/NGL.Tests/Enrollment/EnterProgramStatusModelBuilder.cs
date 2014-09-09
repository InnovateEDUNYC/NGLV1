using NGL.Web.Data.Entities;
using NGL.Web.Models.Enrollment;

namespace NGL.Tests.Enrollment
{
    public class EnterProgramStatusModelBuilder
    {
        private bool? _testingAccommodation = true;
        private readonly bool? _specialEducation = true;
        private bool? _mcKinneyVento = false;
        private readonly bool? _titleParticipation = true;
        private readonly bool? _bilingualProgram = false;
        private readonly bool? _englishAsSecondLanguage = true;
        private readonly bool? _gifted = true;
        private const SchoolFoodServicesEligibilityTypeEnum FoodServiceEligibilityStatus = SchoolFoodServicesEligibilityTypeEnum.Fullprice;

        public EnterProgramStatusModel Build()
        {
            return new EnterProgramStatusModel
            {
                TestingAccommodation = _testingAccommodation,
                SpecialEducation = _specialEducation,
                McKinneyVento = _mcKinneyVento,
                TitleParticipation = _titleParticipation,
                BilingualProgram = _bilingualProgram,
                EnglishAsSecondLanguage = _englishAsSecondLanguage,
                Gifted = _gifted,
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

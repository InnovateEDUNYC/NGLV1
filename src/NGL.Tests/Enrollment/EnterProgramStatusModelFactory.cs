using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Enrollment;

namespace NGL.Tests.Enrollment
{
    public class EnterProgramStatusModelFactory
    {
        private static bool? TestingAccommodation = true;
        private static bool? SpecialEducation = true;
        private static bool? McKinneyVento = false;
        private static bool? TitleParticipation = true;
        private static bool? BilingualProgram = false;
        private static bool? EnglishAsSecondLanguage = true;
        private static bool? Gifted = true;
        private const SchoolFoodServicesEligibilityTypeEnum FoodServiceEligibilityStatus = SchoolFoodServicesEligibilityTypeEnum.Fullprice;

        private static readonly HttpPostedFileBase TestingAccommodationFile = null;
        private static readonly HttpPostedFileBase SpecialEducationFile = null;
        private static readonly HttpPostedFileBase McKinneyVentoFile = null;
        private static readonly HttpPostedFileBase TitleParticipationFile = null;
        
        public static EnterProgramStatusModel CreateProgramStatus()
        {
            return new EnterProgramStatusModel
            {
                TestingAccommodation = TestingAccommodation,
                SpecialEducation = SpecialEducation,
                McKinneyVento = McKinneyVento,
                TitleParticipation = TitleParticipation,
                BilingualProgram = BilingualProgram,
                EnglishAsSecondLanguage = EnglishAsSecondLanguage,
                Gifted = Gifted,
                FoodServicesEligibilityStatus = FoodServiceEligibilityStatus,
                TestingAccommodationFile = TestingAccommodationFile,
                SpecialEducationFile = SpecialEducationFile,
                McKinneyVentoFile = McKinneyVentoFile,
                TitleParticipationFile = TitleParticipationFile
            };
        }
        
    }
}

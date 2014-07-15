using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class EnterProgramStatusModelToStudentProgramStatusMapper : MapperBase<EnterProgramStatusModel, StudentProgramStatus>
    {
        public override void Map(EnterProgramStatusModel source, StudentProgramStatus target)
        {
            target.TestingAccommodation = source.TestingAccommodation.GetValueOrDefault();
            target.BilingualProgram = source.BilingualProgram.GetValueOrDefault();
            target.EnglishAsSecondLanguage = source.EnglishAsSecondLanguage.GetValueOrDefault();
            target.SchoolFoodServicesEligibilityTypeId = (int)source.FoodServiceEligibilityStatus;
            target.Gifted = source.Gifted.GetValueOrDefault();
            target.SpecialEducation = source.SpecialEducation.GetValueOrDefault();
            target.TitleParticipation = source.TitleParticipation.GetValueOrDefault();
            target.McKinneyVento = source.McKinneyVento.GetValueOrDefault();
        }
    }
}
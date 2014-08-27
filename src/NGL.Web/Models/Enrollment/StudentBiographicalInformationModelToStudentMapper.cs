using System;
using System.Collections.Generic;
using System.Linq;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class StudentBiographicalInformationModelToStudentMapper : MapperBase<StudentBiographicalInformationModel, Data.Entities.Student>
    {
        public override void Map(StudentBiographicalInformationModel source, Data.Entities.Student target)
        {
            target.BirthDate = DateTime.Parse(source.BirthDate);
            target.SexTypeId = (int) source.Sex;
            target.HispanicLatinoEthnicity = source.HispanicLatinoEthnicity;
            target.StudentRaces = new List<StudentRace>
            {
                new StudentRace {RaceTypeId = (int) source.Race}
            };

            var studentHomeLanguageUse = new StudentLanguageUse
            {
                LanguageDescriptorId = (int) source.HomeLanguage,
                LanguageUseTypeId = (int) LanguageUseTypeEnum.Homelanguage
            };

            var studentLanguage = new StudentLanguage
            {
                LanguageDescriptorId = (int) source.HomeLanguage,
                StudentLanguageUses = new List<StudentLanguageUse> { studentHomeLanguageUse}
            };

            target.StudentLanguages = new List<StudentLanguage> {studentLanguage};
        }
    }
}

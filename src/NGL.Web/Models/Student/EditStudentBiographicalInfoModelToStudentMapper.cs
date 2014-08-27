using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class EditStudentBiographicalInfoModelToStudentMapper : MapperBase<EditStudentBiographicalInfoModel, Data.Entities.Student>
    {
        public override void Map(EditStudentBiographicalInfoModel source, Data.Entities.Student target)
        {
            target.BirthDate = DateTime.Parse(source.BirthDate);
            target.SexTypeId = (int) source.Sex;
            target.HispanicLatinoEthnicity = source.HispanicLatinoEthnicity;

            if (RaceHasBeenUpdated(source, target))
                MapStudentRace(source, target);

            if (LanguageHasBeenUpdated(source, target))
                MapLanguage(source, target);
        }

        private static void MapLanguage(EditStudentBiographicalInfoModel source, Data.Entities.Student target)
        {
            var studentHomeLanguageUse = new StudentLanguageUse
            {
                LanguageDescriptorId = (int) source.HomeLanguage,
                LanguageUseTypeId = (int) LanguageUseTypeEnum.Homelanguage
            };

            var studentLanguage = new StudentLanguage
            {
                LanguageDescriptorId = (int) source.HomeLanguage,
                StudentLanguageUses = new List<StudentLanguageUse> {studentHomeLanguageUse}
            };

            target.StudentLanguages = new List<StudentLanguage> {studentLanguage};
        }

        private static bool LanguageHasBeenUpdated(EditStudentBiographicalInfoModel source, Data.Entities.Student target)
        {
            return !target.StudentLanguages.IsNullOrEmpty() &&
                   target.StudentLanguages.First().LanguageDescriptorId != (int) source.HomeLanguage;
        }

        private static void MapStudentRace(EditStudentBiographicalInfoModel source, Data.Entities.Student target)
        {
            target.StudentRaces = new List<StudentRace>
            {
                new StudentRace {RaceTypeId = (int) source.Race}
            };
        }

        private static bool RaceHasBeenUpdated(EditStudentBiographicalInfoModel source, Data.Entities.Student target)
        {
            return !target.StudentRaces.IsNullOrEmpty() && target.StudentRaces.First().RaceTypeId != (int)source.Race;
        }
    }
}

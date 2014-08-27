using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class StudentBiographicalInformationModelToStudentMapper : MapperBase<StudentBiographicalInformationModel, Data.Entities.Student>
    {
        public override void Map(StudentBiographicalInformationModel source, Data.Entities.Student target)
        {
            target.BirthDate = DateTime.Parse(source.BirthDate);
            target.SexTypeId = (int) source.Sex.GetValueOrDefault();
            target.HispanicLatinoEthnicity = source.HispanicLatinoEthnicity;

            if (RaceHasBeenUpdated(source, target))
                MapStudentRace(source, target);

            if (LanguageHasBeenUpdated(source, target))
                MapLanguage(source, target);
        }

        private static void MapLanguage(StudentBiographicalInformationModel source, Data.Entities.Student target)
        {
            var studentHomeLanguageUse = new StudentLanguageUse
            {
                LanguageDescriptorId = (int) source.HomeLanguage.GetValueOrDefault(),
                LanguageUseTypeId = (int) LanguageUseTypeEnum.Homelanguage
            };

            var studentLanguage = new StudentLanguage
            {
                LanguageDescriptorId = (int) source.HomeLanguage.GetValueOrDefault(),
                StudentLanguageUses = new List<StudentLanguageUse> {studentHomeLanguageUse}
            };

            target.StudentLanguages = new List<StudentLanguage> {studentLanguage};
        }

        private static bool LanguageHasBeenUpdated(StudentBiographicalInformationModel source, Data.Entities.Student target)
        {
            var languageHasBeenUpdated = !target.StudentLanguages.IsNullOrEmpty() &&
                   target.StudentLanguages.First().LanguageDescriptorId != (int) source.HomeLanguage.GetValueOrDefault();


            var languageIsBeingSetForTheFirstTime = target.StudentLanguages.IsNullOrEmpty();
            return languageHasBeenUpdated || languageIsBeingSetForTheFirstTime;

        }

        private static void MapStudentRace(StudentBiographicalInformationModel source, Data.Entities.Student target)
        {
            target.StudentRaces = new List<StudentRace>
            {
                new StudentRace {RaceTypeId = (int) source.Race.GetValueOrDefault()}
            };
        }

        private static bool RaceHasBeenUpdated(StudentBiographicalInformationModel source, Data.Entities.Student target)
        {
            return !target.StudentRaces.IsNullOrEmpty() && target.StudentRaces.First().RaceTypeId != (int)source.Race;
        }
    }
}

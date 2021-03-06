﻿using System.Collections.Generic;
using System.Linq;
using Humanizer;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class StudentToBiographicalInfoModelMapper : MapperBase<Data.Entities.Student, EditableStudentBiographicalInfoModel>
    {
        public override void Map(Data.Entities.Student source, EditableStudentBiographicalInfoModel target)
        {
            target.StudentUsi = source.StudentUSI;
            target.BirthDate = source.BirthDate.ToShortDateString();
            target.HispanicLatinoEthnicity = source.HispanicLatinoEthnicity;
            target.Sex = (SexTypeEnum) source.SexTypeId;
            target.Race = (RaceTypeEnum)source.StudentRaces.First().RaceTypeId;
            target.RaceForDisplay = target.Race.Humanize();
            MapHomeLanguage(source, target);
        }

        private static void MapHomeLanguage(Data.Entities.Student source, EditableStudentBiographicalInfoModel target)
        {
            var homeLanguage = GetAllHomeLanguages(source).First();
            target.HomeLanguage = (LanguageDescriptorEnum)homeLanguage.LanguageDescriptorId;
        }

        private static IEnumerable<StudentLanguage> GetAllHomeLanguages(Data.Entities.Student source)
        {
            return source.StudentLanguages.Where(
                language => language.StudentLanguageUses.Any(
                    languageUse => languageUse.LanguageUseTypeId.Equals((int)LanguageUseTypeEnum.Homelanguage)));
        }
    }
}
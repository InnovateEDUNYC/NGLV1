using System.Collections.Generic;
using System.Linq;
using Humanizer;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class StudentToProfileHomeLanguageModelMapper : MapperBase<Data.Entities.Student, ProfileHomeLanguageModel>
    {
        public override void Map(Data.Entities.Student source, ProfileHomeLanguageModel target)
        {
            var homeLanguage = GetAllHomeLanguagesOfStudent(source).First();
            target.HomeLanguage = ((LanguageDescriptorEnum) homeLanguage.LanguageDescriptorId).Humanize();
        }

        private IEnumerable<StudentLanguage> GetAllHomeLanguagesOfStudent(Data.Entities.Student source)
        {
            return source.StudentLanguages.Where(
                language => language.StudentLanguageUses.Any(
                    languageUse => languageUse.LanguageUseTypeId.Equals((int) LanguageUseTypeEnum.Homelanguage)));
        }
    }
}
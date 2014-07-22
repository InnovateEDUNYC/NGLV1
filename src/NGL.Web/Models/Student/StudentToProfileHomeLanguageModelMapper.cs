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
            target.HomeLanguages = new List<string>();
            var homeLanguages = GetAllHomeLanguagesOfStudent(source);

            foreach (var language in homeLanguages)
            {
                var humanizedLanguage = ((LanguageDescriptorEnum) language.LanguageDescriptorId).Humanize();
                target.HomeLanguages.Add(humanizedLanguage);
            }
        }

        private IEnumerable<StudentLanguage> GetAllHomeLanguagesOfStudent(Data.Entities.Student source)
        {
            return source.StudentLanguages.Where(
                language => language.StudentLanguageUses.Any(
                    languageUse => languageUse.LanguageUseTypeId.Equals((int) LanguageUseTypeEnum.Homelanguage)));
        }
    }
}
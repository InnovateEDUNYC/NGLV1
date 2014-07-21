using NGL.Web.Data.Entities;

namespace NGL.Tests.Student
{
    public static class StudentLanguageFactory
    {
        public const int LanguageDescriptorId = (int) LanguageDescriptorEnum.English;
        private const int LanguageUseTypeId = (int) LanguageUseTypeEnum.Homelanguage;


        public static StudentLanguage CreateStudentLanguageWithHomeUse()
        {
            var language = CreateStudentLanguage();
            language.StudentLanguageUses.Add(CreateHomeLanguageUse());

            return language;
        }

        private static StudentLanguage CreateStudentLanguage()
        {
            return new StudentLanguage
            {
                LanguageDescriptorId = LanguageDescriptorId
            };
        }

        private static StudentLanguageUse CreateHomeLanguageUse()
        {
            return new StudentLanguageUse
            {
                LanguageUseTypeId = LanguageUseTypeId,
                LanguageDescriptorId = LanguageDescriptorId
            };
        }


    }
}

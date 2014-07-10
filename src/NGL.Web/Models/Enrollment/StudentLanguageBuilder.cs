using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class StudentHomeLanguageBuilder
    {
        private const int HomeLanguageTypeId = (int)LanguageUseTypeEnum.Homelanguage;
        public StudentLanguage Build(CreateStudentModel source)
        {
            var studentLanguage = new StudentLanguage
            {
                LanguageDescriptorId = (int) source.LanguageDescriptorEnum.GetValueOrDefault()
            };

            var studentHomeLanguageUse = new StudentLanguageUse
            {
                LanguageDescriptorId = (int) source.LanguageDescriptorEnum.GetValueOrDefault(),
                LanguageUseTypeId = HomeLanguageTypeId
            };

            studentLanguage.StudentLanguageUses.Add(studentHomeLanguageUse);

            return studentLanguage;
        }
    }
}
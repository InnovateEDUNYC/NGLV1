using System.Collections.Generic;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class StudentHomeLanguageMapper : MapperBase<CreateStudentModel, StudentLanguage>
    {
        private const int HomeLanguageTypeId = (int)LanguageUseTypeEnum.Homelanguage;
        public override void Map(CreateStudentModel source, StudentLanguage target)
        {
            target.LanguageDescriptorId = (int) source.HomeLanguage.GetValueOrDefault();

            var studentHomeLanguageUse = new StudentLanguageUse
            {
                LanguageDescriptorId = (int) source.HomeLanguage.GetValueOrDefault(),
                LanguageUseTypeId = HomeLanguageTypeId
            };

            target.StudentLanguageUses = new List<StudentLanguageUse> {studentHomeLanguageUse};
        }
    }
}
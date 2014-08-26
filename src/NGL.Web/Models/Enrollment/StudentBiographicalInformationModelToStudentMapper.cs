using System;
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
            target.StudentRaces.First().RaceTypeId = (int) source.Race;
            target.StudentLanguages.First().LanguageDescriptorId = (int) source.HomeLanguage;
            target.StudentLanguages.First().LanguageDescriptorId = (int) source.HomeLanguage;
            target.StudentLanguages.First().StudentLanguageUses.First().LanguageDescriptorId = (int) source.HomeLanguage;
        }

    }
}

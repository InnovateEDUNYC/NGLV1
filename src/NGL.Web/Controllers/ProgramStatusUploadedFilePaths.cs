using System;

namespace NGL.Web.Controllers
{
    public class ProgramStatusUploadedFilePaths
    {
        public String SpecialEducation { get; private set; }
        public String TestingAccomodation { get; private set; }
        public String TitleParticipation { get; private set; }
        public String McKinneyVento { get; private set; }

        public ProgramStatusUploadedFilePaths(string specialEducation, string testingAccomodation, string titleParticipation, string mcKinneyVento)
        {
            SpecialEducation = specialEducation;
            TestingAccomodation = testingAccomodation;
            TitleParticipation = titleParticipation;
            McKinneyVento = mcKinneyVento;
        }
    }
}
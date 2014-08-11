using System;
using System.Collections.Generic;

namespace NGL.Web.Models.Assessment
{
    public class AssessmentResultModel
    {
        public int StudentUsi { get; set; }
        public string StudentName { get; set; }
        public string Session { get; set; }
        public int? SessionId { get; set; }
        public int? DayTo { get; set; }
        public int? DayFrom { get; set; }
        public string DateRange { get; set; }
        public string ProfilePhotoUrl { get; set; }

        public IList<AssessmentResultRowModel> AssessmentResultRows { get; set; }

        public void Update(Data.Entities.Student student, string profilePhotoUrl, int? sessionId, int dayFrom, int dayTo)
        {
            StudentUsi = student.StudentUSI;
            StudentName = String.Join(" ", student.FirstName, student.LastSurname);
            ProfilePhotoUrl = profilePhotoUrl;
            SessionId = sessionId;
            DayFrom = dayFrom;
            DayTo = dayTo;
        }
    }
}
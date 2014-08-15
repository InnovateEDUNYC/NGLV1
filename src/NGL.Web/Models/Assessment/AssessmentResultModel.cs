using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NGL.Web.Models.Assessment
{
    public class AssessmentResultModel
    {
        [Display(Name="Student USI")]
        public int StudentUsi { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Session { get; set; }
        public int? SessionId { get; set; }
        public int DayTo { get; set; }
        public int DayFrom { get; set; }
        public string DateRange { get; set; }
        public string ProfilePhotoUrl { get; set; }

        public IList<AssessmentResultRowModel> AssessmentResultRows { get; set; }

        public void Update(Data.Entities.Student student, string profilePhotoUrl, int? sessionId, int dayFrom, int dayTo)
        {
            StudentUsi = student.StudentUSI;
            FirstName = student.FirstName;
            LastName = student.LastSurname;
            ProfilePhotoUrl = profilePhotoUrl;
            SessionId = sessionId;
            DayFrom = dayFrom;
            DayTo = dayTo;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChameleonForms.Attributes;

namespace NGL.Web.Models.Schedule
{
    public class SetModel
    {
        public string Name { get; set; }
        public int StudentUsi { get; set; }
        public string ProfilePhotoUrl { get; set; }
        public List<SessionListItemModel> Sessions { get; set; }
        [ExistsIn("Sessions", "SessionId", "SessionName", false)]
        public string Session { get; set; }
        [Required]
        public DateTime BeginDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public int SectionId { get; set; }

        public List<string> CurrentlyEnrolledSections { get; set; }


        public static SetModel CreateNewWith(Data.Entities.Student student, string profilePhotoUrl, List<SessionListItemModel> sessions, SessionListItemModel session, List<string> currentlyEnrolledSections)
        {
            var sessionIndex = sessions.FindIndex(s => s.SessionName == session.SessionName);
            var setModel = new SetModel
            {
                Name = String.Join(" ", student.FirstName, student.LastSurname),
                StudentUsi = student.StudentUSI,
                ProfilePhotoUrl = profilePhotoUrl,
                Sessions = sessions,
                Session = GetChameleonFormsIndexValue(sessionIndex),
                BeginDate = session.BeginDate,
                EndDate = session.EndDate,
                CurrentlyEnrolledSections = currentlyEnrolledSections
            };

            return setModel;
        }

        private static string GetChameleonFormsIndexValue(int sessionIndex)
        {
            return (sessionIndex + 1).ToString();
        }
    }

}
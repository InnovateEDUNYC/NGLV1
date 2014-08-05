using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChameleonForms.Attributes;

namespace NGL.Web.Models.Schedule
{
    public class SetModel
    {
        public string StudentName { get; set; }
        public int StudentUsi { get; set; }
        public string ProfilePhotoUrl { get; set; }
        public List<SessionListItemModel> Sessions { get; set; }
        public int Session { get; set; }

        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public int SectionId { get; set; }
        public string ErrorMessage { get; set; }

        public List<Section.SectionListItemModel> CurrentlyEnrolledSections { get; set; }


        public static SetModel CreateNewWith(Data.Entities.Student student, string profilePhotoUrl, List<SessionListItemModel> sessions, SessionListItemModel session, List<Section.SectionListItemModel> currentlyEnrolledSections)
        {
            var setModel = new SetModel
            {
                StudentName = String.Join(" ", student.FirstName, student.LastSurname),
                StudentUsi = student.StudentUSI,
                ProfilePhotoUrl = profilePhotoUrl,
                Sessions = sessions,
                Session = session.SessionId,
                BeginDate = session.BeginDate,
                EndDate = session.EndDate,
                CurrentlyEnrolledSections = currentlyEnrolledSections
            };

            return setModel;
        }
    }
}
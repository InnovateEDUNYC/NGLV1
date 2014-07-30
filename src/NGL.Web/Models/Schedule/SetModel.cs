using System;
using System.Collections.Generic;
using ChameleonForms.Attributes;

namespace NGL.Web.Models.Schedule
{
    public class SetModel
    {
        public SetModel()
        {
            this.Sessions = new List<SessionListItemModel>();
        }
        public string Name { get; set; }
        public int StudentUsi { get; set; }
        public string ProfilePhotoUrl { get; set; }
//        public int SectionId { get; set; }
//        public DateTime BeginDate { get; set; }
//        public DateTime EndDate { get; set; }
        public List<SessionListItemModel> Sessions { get; set; }

        [ExistsIn("Sessions", "SessionId", "SessionName")]
        public string Session { get; set; }
    }

}
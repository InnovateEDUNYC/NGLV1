namespace NGL.Web.Models.Schedule
{
    public class SessionListItemModel
    {
        public string SessionName { get; set; }
        public int SessionId { get; set; }
        public System.DateTime BeginDate { get; set; }
        public System.DateTime EndDate { get; set; }
    }
}
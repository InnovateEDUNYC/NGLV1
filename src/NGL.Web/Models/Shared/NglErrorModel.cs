namespace NGL.Web.Models.Shared
{
    public class NglErrorModel
    {
        public string Field { get; set; }
        public string Message { get; set; }

        public NglErrorModel(string field, string message)
        {
            Field = field;
            Message = message;
        }
    }
}
namespace NGL.Web.Models.Assessment
{
    public class EnterResultsStudentModel
    {
        public string Name { get; set; }
        public int StudentUsi { get; set; }
        public decimal? AssessmentResult { get; set; }
        public int AssessmentIdentity { get; set; }
        public string ProfileThumbnailUrl { get; set; }
    }
}
namespace NGL.Web.Models.Student
{
    public class ProfileParentModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string Relationship { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool? SameAddressAsStudent { get; set; }
        public ProfileParentAddressModel ProfileParentAddressModel { get; set; }
    }
}
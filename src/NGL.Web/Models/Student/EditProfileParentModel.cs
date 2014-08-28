using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class EditProfileParentModel
    {
        public int ParentUSI { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SexTypeEnum Sex { get; set; }
        public RelationTypeEnum Relationship { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool? SameAddressAsStudent { get; set; }
        public ProfileParentAddressModel ProfileParentAddressModel { get; set; }
    }
}
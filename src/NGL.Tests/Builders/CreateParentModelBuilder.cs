using NGL.Web.Data.Entities;
using NGL.Web.Models.Enrollment;

namespace NGL.Tests.Builders
{
    public class CreateParentModelBuilder
    {
        private const string FirstName = "Leroy";
        private const string LastName = "Jenkins";
        private const SexTypeEnum Sex = SexTypeEnum.Male;
        private const RelationTypeEnum RelationshipToStudent = RelationTypeEnum.Father;
        private const string PhoneNumber = "928-326-4567";
        private const bool MakeThisPrimaryContact = true;
        private string _emailAddress = null;
        private const bool SameAddressAsStudent = false;
        private const string Address = "890 Willow Ave";
        private const string Address2 = "flr 4";
        private const string City = "Honolulu";
        private const StateAbbreviationTypeEnum State = StateAbbreviationTypeEnum.NM;
        private const string PostalCode = "27890";

        public CreateParentModelBuilder WithEmailAddress(string emailAddress = "leroy@jenk.net")
        {
            _emailAddress = emailAddress;
            return this;
        }

        public CreateParentModel Build()
        {
            return new CreateParentModel
            {
                FirstName = FirstName,
                LastName = LastName,
                Sex = Sex,
                RelationshipToStudent = RelationshipToStudent,
                TelephoneNumber = PhoneNumber,
                EmailAddress = _emailAddress,
                SameAddressAsStudent = SameAddressAsStudent,
                Address = Address,
                Address2 = Address2,
                City = City,
                State = State,
                PostalCode = PostalCode,
                MakeThisPrimaryContact = MakeThisPrimaryContact
            };
        }
    }
}

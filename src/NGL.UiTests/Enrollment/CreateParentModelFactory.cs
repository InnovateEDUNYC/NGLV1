using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Enrollment;

namespace NGL.UiTests.Enrollment
{
    public static class ParentModelFactory
    {
        private const string FirstName = "Leroy";
        private const string LastName = "Jenkins";
        private const SexTypeEnum Sex = SexTypeEnum.Male;
        private const RelationTypeEnum RelationshipToStudent = RelationTypeEnum.Father;
        private const string PhoneNumber = "928-326-4567";
        private const bool MakeThisPrimaryContact = true;
        private const string Email = "leroy@jenk.net";
        private const bool SameAddressAsStudent = false;
        private const string Address = "890 Willow Ave";
        private const string Address2 = "flr 4";
        private const string City = "Honolulu";
        private const StateAbbreviationTypeEnum State = StateAbbreviationTypeEnum.NM;
        private const string PostalCode = "27890" ;

        public static CreateParentModel CreateParentWithAddress()
        {
            return new CreateParentModel
            {
                FirstName = FirstName,
                LastName = LastName,
                Sex = Sex,
                RelationshipToStudent = RelationshipToStudent,
                TelephoneNumber = PhoneNumber,
                EmailAddress = Email,
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

using System.Linq;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Student
{
    public static class ParentFactory
    {
        public const string FirstName = "Leroy";
        public const string LastName = "Jenkins";
        public const int Sex = (int) SexTypeEnum.Male;
        public const string PhoneNumber = "928-326-4567";
        private const int PhoneNumberType = (int) TelephoneNumberTypeEnum.Emergency1;
        public const string Email = "leroy@jenk.net";
        private const bool DoesNotLiveWithStudent = false;


        public static Parent CreateParentWithoutAddress()
        {
            var parent = CreateParent();
            parent.ParentTelephones.Add(CreateParentPhoneNumber());
            parent.ParentElectronicMails.Add(CreateParentEmailAddress());

            return parent;
        }

        public static Parent CreateParentWithAddress()
        {
            var parent = CreateParentWithoutAddress();
            var parentAddress = ParentAddressFactory.CreateParentHomeAddress();
            parent.ParentAddresses.Add(parentAddress);

            return parent;
        }


        private static Parent CreateParent()
        {
            return new Parent
            {
                FirstName = FirstName,
                LastSurname = LastName,
                SexTypeId = Sex,
            };
        }

        private static ParentTelephone CreateParentPhoneNumber()
        {
            return new ParentTelephone
            {
                TelephoneNumber = PhoneNumber,
                TelephoneNumberTypeId = PhoneNumberType
            };
        }

        private static ParentElectronicMail CreateParentEmailAddress()
        {
            return new ParentElectronicMail
            {
                ElectronicMailAddress = Email
            };
        }

    }
}

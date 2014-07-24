using System.Linq;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Student
{
    public static class ParentFactory
    {
        private const string FirstName = "Leroy";
        private const string LastName = "Jenkins";
        private const int Sex = (int) SexTypeEnum.Male;
        private const string PhoneNumber = "928-326-4567";
        private const int PhoneNumberType = (int) TelephoneNumberTypeEnum.Emergency1;
        private const string Email = "leroy@jenk.net";

        public static Parent CreateParentWithoutAddress()
        {
            var parent = CreateParentShell();
            parent.ParentTelephones.Add(CreateParentPhoneNumber());
            parent.ParentElectronicMails.Add(CreateParentEmailAddress());

            return parent;
        }

        public static Parent CreateParentWithoutAddress(string firstName)
        {
            var parent = CreateParentShell(firstName);
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


        private static Parent CreateParentShell()
        {
            return new Parent
            {
                FirstName = FirstName,
                LastSurname = LastName,
                SexTypeId = Sex,
            };
        }

        private static Parent CreateParentShell(string firstName)
        {
            return new Parent
            {
                FirstName = firstName,
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

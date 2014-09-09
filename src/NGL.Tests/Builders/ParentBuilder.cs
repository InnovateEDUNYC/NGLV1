using System.Collections.Generic;
using NGL.Tests.Student;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class ParentBuilder
    {
        private const string FirstName = "Leroy";
        private const string LastSurname = "Jenkins";
        private readonly int? _sexTypeId = (int?) SexTypeEnum.Male;
        private readonly ICollection<ParentAddress> _parentAddresses = new List<ParentAddress>();
        private readonly ICollection<ParentTelephone> _phoneNumbers = new List<ParentTelephone>();
        private readonly ICollection<ParentElectronicMail> _emails = new List<ParentElectronicMail>();

        public Parent Build()
        {
            return new Parent
            {
                FirstName = FirstName,
                LastSurname = LastSurname,
                SexTypeId = _sexTypeId,
                ParentAddresses = _parentAddresses,
                ParentTelephones = _phoneNumbers,
                ParentElectronicMails = _emails,
            };
        }

        public ParentBuilder WithAddress()
        {
            _parentAddresses.Add(ParentAddressFactory.CreateParentHomeAddress());
            return this;
        }

        public ParentBuilder WithPhoneNumber()
        {
            _phoneNumbers.Add(new ParentTelephone
            {
                TelephoneNumber = "123-456-7890",
                TelephoneNumberTypeId = (int) TelephoneNumberTypeEnum.Emergency1,
            });
            return this;
        }

        public ParentBuilder WithEmail()
        {

            _emails.Add(new ParentElectronicMail
            {
                ElectronicMailAddress = "Leroy@Jenkins.com",
                ElectronicMailTypeId = (int) ElectronicMailTypeEnum.HomePersonal
            });
            return this;
        }
    }
}

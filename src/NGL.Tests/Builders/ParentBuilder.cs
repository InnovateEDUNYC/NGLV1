using System.Collections.Generic;
using NGL.Tests.Student;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class ParentBuilder
    {
        private string _firstName = "Leroy";
        private string _lastSurname = "Jenkins";
        private int? _sexTypeId = (int?) SexTypeEnum.Male;
        private ICollection<ParentAddress> _parentAddresses = new List<ParentAddress>();
        private ICollection<ParentTelephone> _phoneNumbers = new List<ParentTelephone>();
        private ICollection<ParentElectronicMail> _emails = new List<ParentElectronicMail>();

        public Parent Build()
        {
            return new Parent
            {
                FirstName = _firstName,
                LastSurname = _lastSurname,
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

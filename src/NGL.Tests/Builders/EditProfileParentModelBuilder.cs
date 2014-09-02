using System.Collections.Generic;
using NGL.Tests.Student;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Student;

namespace NGL.Tests.Builders
{
    public class EditProfileParentModelBuilder
    {
        private int _parentUsi = 123;
        private string _email = "maria@grandma.net";
        private string _firstName = "Maria";
        private string _lastName = "Gomez";
        private RelationTypeEnum _relationTypeEnum = RelationTypeEnum.Motherstep;
        private SexTypeEnum _sexTypeEnum = SexTypeEnum.Female;
        private string _telephoneNumber = "555-999-9999";
        private readonly EditableParentAddressModel _parentAddressModel = new EditableParentAddressModelBuilder().Build();

        public EditableParentModel Build()
        {
            return new EditableParentModel
            {
                EditableParentAddressModel = _parentAddressModel,
                ParentUSI = _parentUsi,
                EmailAddress = _email,
                FirstName = _firstName,
                LastName = _lastName,
                Relationship = _relationTypeEnum,
                Sex = _sexTypeEnum,
                TelephoneNumber = _telephoneNumber
            };
        }

        public EditProfileParentModelBuilder WithBlankEmail()
        {
            _email = null;
            return this;
        }
    }

    internal class EditableParentAddressModelBuilder
    {
        private string _address = "123 Skyscraper";
        private string _address2 = "Top floor";
        private string _city = "Detroit";
        private StateAbbreviationTypeEnum? _state = StateAbbreviationTypeEnum.AR;
        private string _postalCode = "12321";

        public EditableParentAddressModel Build()
        {
            return new EditableParentAddressModel
            {
                Address = _address,
                Address2 = _address2,
                City = _city,
                State = _state,
                PostalCode = _postalCode
            };
        }
    }
}

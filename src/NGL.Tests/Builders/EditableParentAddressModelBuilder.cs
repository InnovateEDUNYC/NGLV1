using NGL.Web.Data.Entities;
using NGL.Web.Models.Student;

namespace NGL.Tests.Builders
{
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

        public EditableParentAddressModelBuilder WithAddress(string address)
        {
            _address = address;
            return this;
        }
    }
}
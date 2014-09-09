using NGL.Web.Data.Entities;
using NGL.Web.Models.Student;

namespace NGL.Tests.Builders
{
    internal class EditableParentAddressModelBuilder
    {
        private string _address = "123 Skyscraper";
        private const string Address2 = "Top floor";
        private const string City = "Detroit";
        private readonly StateAbbreviationTypeEnum? _state = StateAbbreviationTypeEnum.AR;
        private const string PostalCode = "12321";

        public EditableParentAddressModel Build()
        {
            return new EditableParentAddressModel
            {
                Address = _address,
                Address2 = Address2,
                City = City,
                State = _state,
                PostalCode = PostalCode
            };
        }

        public EditableParentAddressModelBuilder WithAddress(string address)
        {
            _address = address;
            return this;
        }
    }
}
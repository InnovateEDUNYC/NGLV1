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

        public EditProfileParentModel Build()
        {
            return new EditProfileParentModel
            {
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
}

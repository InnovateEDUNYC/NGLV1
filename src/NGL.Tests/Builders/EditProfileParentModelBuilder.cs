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
        private bool _sameAddressAsStudent = false;

        public EditProfileParentModel Build()
        {
            return new EditProfileParentModel
            {
                EditableParentAddressModel = _parentAddressModel,
                ParentUSI = _parentUsi,
                EmailAddress = _email,
                FirstName = _firstName,
                LastName = _lastName,
                Relationship = _relationTypeEnum,
                Sex = _sexTypeEnum,
                TelephoneNumber = _telephoneNumber,
                SameAddressAsStudent = _sameAddressAsStudent
            };
        }

        public EditProfileParentModelBuilder WithBlankEmail()
        {
            _email = null;
            return this;
        }

        public EditProfileParentModelBuilder WithNewValues()
        {
            _email = "123@bam.com";
            _firstName = "Mike";
            _lastName = "Simpson";
            _relationTypeEnum = RelationTypeEnum.Cousin;
            _sameAddressAsStudent = false;
            _telephoneNumber = "129099";
            return this;
        }
    }
}

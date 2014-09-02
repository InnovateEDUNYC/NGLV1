using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class EditProfileParentModelToParentMapper : MapperBase<EditProfileParentModel, Parent>
    {
        private readonly IMapper<EditableParentAddressModel, Parent> _addressMapper;

        public EditProfileParentModelToParentMapper(IMapper<EditableParentAddressModel, Parent> addressMapper)
        {
            _addressMapper = addressMapper;
        }

        public override void Map(EditProfileParentModel source, Parent target)
        {
            target.FirstName = source.FirstName;
            target.LastSurname = source.LastName;
            target.SexTypeId = (int)source.Sex;
            target.ParentTelephones.First().TelephoneNumber = source.TelephoneNumber;
            target.StudentParentAssociations.First().RelationTypeId = (int)source.Relationship;
            target.StudentParentAssociations.First().LivesWith = source.SameAddressAsStudent;

            UpdateEmail(source, target);
            UpdateAddress(source, target);
        }

        private void UpdateAddress(EditProfileParentModel source, Parent target)
        {
            if (!source.SameAddressAsStudent)
            {
                if (AddressHasBeenChanged(source, target))
                    _addressMapper.Map(source.EditableParentAddressModel, target);
            }
            else
            {
                target.ParentAddresses = new List<ParentAddress>();
            }
        }

        private void UpdateEmail(EditProfileParentModel source, Parent target)
        {
            if (source.EmailAddress.IsNullOrEmpty())
            {
                target.ParentElectronicMails = new List<ParentElectronicMail>();
            }
            else
            {
                if (target.ParentElectronicMails.IsNullOrEmpty())
                    target.ParentElectronicMails.Add(BuildEmail());
                target.ParentElectronicMails.First().ElectronicMailAddress = source.EmailAddress;
            }
        }

        private bool AddressHasBeenChanged(EditProfileParentModel source, Parent target)
        {
            var targetAddress = target.ParentAddresses.FirstOrDefault();
            var sourceAddress = source.EditableParentAddressModel;

            return targetAddress == null
            ||   targetAddress.StreetNumberName != sourceAddress.Address 
            || targetAddress.ApartmentRoomSuiteNumber != sourceAddress.Address2 
            || targetAddress.City != sourceAddress.City 
            || targetAddress.PostalCode != sourceAddress.PostalCode 
            || targetAddress.StateAbbreviationTypeId != (int)sourceAddress.State.GetValueOrDefault();
        }

        private ParentElectronicMail BuildEmail()
        {
            return new ParentElectronicMail
            {
                ElectronicMailTypeId = (int)ElectronicMailTypeEnum.HomePersonal
            };
        }
    }
}
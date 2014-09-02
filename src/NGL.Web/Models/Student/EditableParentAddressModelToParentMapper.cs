using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class EditableParentAddressModelToParentMapper: MapperBase<EditableParentAddressModel, Parent>
    {
        private const int HomeAddressTypeId = (int)AddressTypeEnum.Home;
        public override void Map(EditableParentAddressModel source, Parent target)
        {
            if (target.ParentAddresses.IsNullOrEmpty())
            {
                target.ParentAddresses.Add(new ParentAddress());
            }
                var parentAddress = target.ParentAddresses.First();

                parentAddress.AddressTypeId = HomeAddressTypeId;
                parentAddress.StreetNumberName = source.Address;
                parentAddress.ApartmentRoomSuiteNumber = source.Address2;
                parentAddress.City = source.City;
                parentAddress.PostalCode = source.PostalCode;
                parentAddress.StateAbbreviationTypeId = (int) source.State.GetValueOrDefault();
        }
    }
}
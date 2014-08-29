using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class EditProfileParentModelToParentMapper : MapperBase<EditableParentModel, Parent>
    {
        public override void Map(EditableParentModel source, Parent target)
        {
            target.FirstName = source.FirstName;
            target.LastSurname = source.LastName;
            target.SexTypeId = (int)source.Sex;
            target.ParentTelephones.First().TelephoneNumber = source.TelephoneNumber;
            target.StudentParentAssociations.First().RelationTypeId = (int)source.Relationship;

            if (source.EmailAddress.IsNullOrEmpty())
            {
                target.ParentElectronicMails = new List<ParentElectronicMail>();
                return;
            }

            if (target.ParentElectronicMails.IsNullOrEmpty())
                target.ParentElectronicMails.Add(BuildEmail());

            target.ParentElectronicMails.First().ElectronicMailAddress = source.EmailAddress;
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
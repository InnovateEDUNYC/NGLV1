using System.Linq;
using Humanizer;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class ParentToProfileParentModelMapper : MapperBase<Parent, ProfileParentModel>
    {
        public override void Map(Parent source, ProfileParentModel target)
        {
            var studentParentAssociation = source.StudentParentAssociations.First();

            target.FirstName = source.FirstName;
            target.LastName = source.LastSurname;
            target.Sex = ((SexTypeEnum) source.SexTypeId).Humanize();
            target.Relationship = ((RelationTypeEnum) studentParentAssociation.RelationTypeId).Humanize();
            target.TelephoneNumber = source.ParentTelephones.First().TelephoneNumber;
            target.EmailAddress = source.ParentElectronicMails.First().ElectronicMailAddress;
            target.SameAddressAsStudent = (bool) studentParentAssociation.LivesWith;

            if (studentParentAssociation.LivesWith == false)
            {
                var parentToProfileParentAddressModelMapper = new ParentToProfileParentAddressModelMapper();
                target.ProfileParentAddressModel = parentToProfileParentAddressModelMapper.Build(source);
            }
        }
    }
}
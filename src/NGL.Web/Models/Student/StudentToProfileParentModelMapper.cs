using System.Linq;
using Humanizer;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class StudentToProfileParentModelMapper : MapperBase<Data.Entities.Student, ProfileParentModel>
    {
        public override void Map(Data.Entities.Student source, ProfileParentModel target)
        {
            var studentParentAssociation = source.StudentParentAssociations.First();
            var parent = studentParentAssociation.Parent;

            target.FirstName = parent.FirstName;
            target.LastName = parent.LastSurname;
            target.Sex = ((SexTypeEnum) parent.SexTypeId).Humanize();
            target.RelationshipToStudent = ((RelationTypeEnum) studentParentAssociation.RelationTypeId).Humanize();
            target.TelephoneNumber = parent.ParentTelephones.First().TelephoneNumber;
            target.EmailAddress = parent.ParentElectronicMails.First().ElectronicMailAddress;
            target.SameAddressAsStudent = (bool) studentParentAssociation.LivesWith;

            if (studentParentAssociation.LivesWith == false)
            {
                var studentToProfileParentAddressModelMapper = new StudentToProfileParentAddressModelMapper();
                target.ProfileParentAddressModel = studentToProfileParentAddressModelMapper.Build(source);
            }
        }
    }
}
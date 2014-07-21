using System.Linq;
using Humanizer;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class StudentToProfileParentModelMapper : MapperBase<Data.Entities.Student, ProfileParentModel>
    {
        public override void Map(Data.Entities.Student source, ProfileParentModel target)
        {
            target.FirstName = source.StudentParentAssociations.First().Parent.FirstName;
            target.LastName = source.StudentParentAssociations.First().Parent.LastSurname;
            target.Sex = ((SexTypeEnum) source.StudentParentAssociations.First().Parent.SexTypeId).Humanize();
            target.RelationshipToStudent = ((RelationTypeEnum) source.StudentParentAssociations.First().RelationTypeId).Humanize();
            target.TelephoneNumber = source.StudentParentAssociations.First().Parent.ParentTelephones.First().TelephoneNumber;
            target.EmailAddress = source.StudentParentAssociations.First().Parent.ParentElectronicMails.First().ElectronicMailAddress;
            target.SameAddressAsStudent = (bool)source.StudentParentAssociations.First().LivesWith;
        }
    }
}
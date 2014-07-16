using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class CreateParentModelToParentMapper : MapperBase<CreateParentModel, Parent>
    {
        public override void Map(CreateParentModel source, Parent target)
        {
            target.FirstName = source.FirstName;
            target.LastSurname = source.LastName;
            target.SexTypeId = (int) source.Sex.GetValueOrDefault();
            var parentTelephone = new ParentTelephone
            {
                TelephoneNumber = source.TelephoneNumber,
                TelephoneNumberTypeId = (int)TelephoneNumberTypeEnum.Emergency1
            };

            target.ParentTelephones.Add(parentTelephone);

            var parentEmail = new ParentElectronicMail
            {
                ElectronicMailAddress = source.EmailAddress,
                ElectronicMailTypeId = (int) ElectronicMailTypeEnum.HomePersonal
            };

            target.ParentElectronicMails.Add(parentEmail);
        }
    }
}
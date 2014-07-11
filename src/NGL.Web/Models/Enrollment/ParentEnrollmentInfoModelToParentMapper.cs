using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class ParentEnrollmentInfoModelToParentMapper : MapperBase<ParentEnrollmentInfoModel, Parent>
    {
        public override void Map(ParentEnrollmentInfoModel source, Parent target)
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
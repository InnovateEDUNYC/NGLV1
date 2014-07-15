using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment.Parent
{
    public class ParentEnrollmentInfoModelToParentMapper : MapperBase<ParentEnrollmentInfoModel, Data.Entities.Parent>
    {
        public override void Map(ParentEnrollmentInfoModel source, Data.Entities.Parent target)
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
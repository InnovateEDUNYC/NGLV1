using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Account
{
    public class AddUserModelToApplicationUserMapper : MapperBase<AddUserModel, ApplicationUser>
    {
        public override void Map(AddUserModel source, ApplicationUser target)
        {
            target.UserName = source.Username;
            target.StaffUSI = source.StaffUSI.GetValueOrDefault();
            target.Email = source.PersonalEmail;
        }
    }
}
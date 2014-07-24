using System.Linq;

namespace NGL.Web.Models.Account
{
    public class StaffToUserModelMapper : MapperBase<Data.Entities.Staff, UserModel>
    {
        public override void Map(Data.Entities.Staff source, UserModel target)
        {
            var user = source.Users.First();
            var role = user.AspNetRoles.FirstOrDefault();
            target.Username = user.UserName;
            target.Role = role == null ? "(role not set)" : role.Name;
            target.StaffUSI = source.StaffUSI;
            target.FirstName = source.FirstName;
            target.LastName = source.LastSurname;
            target.HispanicLatino = source.HispanicLatinoEthnicity;
        }
    }
}
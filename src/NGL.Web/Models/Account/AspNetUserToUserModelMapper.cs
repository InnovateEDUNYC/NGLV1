using System.Linq;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Account
{
    public class AspNetUserToUserModelMapper : MapperBase<AspNetUser, UserModel>
    {
        public override void Map(AspNetUser source, UserModel target)
        {
            var role = source.AspNetRoles.FirstOrDefault();
            target.Username = source.UserName;
            target.Role = role == null ? "(role not set)" : role.Name;
        }
    }
}
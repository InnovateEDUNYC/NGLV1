namespace NGL.Web.Models.Account
{
    public class AddUserModelToStaffMapper: MapperBase<AddUserModel, Data.Entities.Staff>
    {
        public override void Map(AddUserModel source, Data.Entities.Staff target)
        {
            target.LoginId = source.Username;
            target.FirstName = source.FirstName;
            target.LastSurname = source.LastName;
            target.StaffUSI = source.StaffUSI.Value;
            target.HispanicLatinoEthnicity = source.HispanicLatino;
        }
    }
}
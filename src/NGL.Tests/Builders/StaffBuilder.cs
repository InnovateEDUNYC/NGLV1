using System.Collections.Generic;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class StaffBuilder
    {
        private AspNetUser _user;
        public const string FirstName = "FirstName";
        public const string LastName = "LastName";
        public const int StaffUSI = 1;
        public const bool HispanicLatino = true;

        public StaffBuilder WithUser(string username, string role = null)
        {
            var roles = new List<AspNetRole>();
            if (role != null)
                roles.Add(new AspNetRole {Name = role});

            _user = new AspNetUser {UserName = username, AspNetRoles = roles};
            return this;
        }

        public Staff Build()
        {
            var staff = new Staff
            {
                FirstName = FirstName,
                LastSurname = LastName,
                StaffUSI = StaffUSI,
                HispanicLatinoEthnicity = HispanicLatino
            };

            if (_user != null)
                staff.Users.Add(_user);
            
            return staff;
        }
    }
}
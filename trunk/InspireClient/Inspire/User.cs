using System;
using System.Collections.Generic;

namespace Inspire
{
    public class User
    {
        public string GUID { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public List<Role> Roles { get; set; }

        public User()
        {
            GUID = Guid.NewGuid().ToString();
        }

        public static List<PermissionTypes> UserPermision = new List<PermissionTypes>();

        public static string UserName { get; set; }

        public static string UserGuid { get; set; }
    }

    public enum PermissionTypes
    {
        Guest = 1,
        ContentCreator = 2,
        ContentManager = 3,
        Administrator = 4,
    }


    public class Role
    {
        public string GUID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}

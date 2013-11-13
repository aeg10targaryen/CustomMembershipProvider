using System;
using System.Collections.Specialized;
using System.Linq;
using Data.Infrastructure;
using Data.Models.User;

namespace MyMembership
{
    class MyRole : MyRoleProvider
    {
        private string _applicationName;

        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
                throw new ArgumentNullException("config");
            if (string.IsNullOrEmpty(name))
                name = "RoleProvider";
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "RoleProvider");
            }
            base.Initialize(name, config);
            _applicationName = config["applicationName"];
        }

        public override string ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            if (string.IsNullOrEmpty(username))
                throw new Exception("User name is null or empty");
            if (string.IsNullOrEmpty(roleName))
                throw new Exception("Role name is null or empty");
            var user = Repository<User>.Get(d => d.Username == username);
            if (user == null)
                return false;
            var role = Repository<Role>.Get(d => d.RoleName == roleName);
            if (role == null)
                return false;

            var status = Repository<UserInRole>.Get(c => c.RoleId == role.Id && c.UserId == user.Id);
            return status != null;
        }

        public override string[] GetRolesForUser(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new Exception("User name is null or empty");
            var user = Repository<User>.Get(d => d.Username == username);
            if (user == null)
                throw new Exception("user not found");

            var data = Repository<UserInRole>.GetMany(c => c.UserId == user.Id).Select(c => c.Role.RoleName);
            return data.ToArray();
        }

        public override void CreateRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                throw new Exception("Role name is null or empty");
            var role = Repository<Role>.Get(d => d.RoleName == roleName);
            if (role != null)
                throw new Exception("Role not found");

            var newRole = new Role { RoleName = roleName };
            Repository<Role>.Create(newRole);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            if (string.IsNullOrEmpty(roleName))
                throw new Exception("Role name is null or empty");
            var role = Repository<Role>.Get(d => d.RoleName == roleName);
            if (role == null)
                throw new Exception("Role not found");
            if (throwOnPopulatedRole)
            {
                var usersInRole = role.UserInRoles.Any();
                if (usersInRole)
                    throw new Exception("Role in the use from users");
            }
            else
            {
                foreach (var usrLoopVariable in role.UserInRoles)
                {
                    var usr = usrLoopVariable;
                    Repository<User>.Delete(usr.User.Id);
                }
            }
            Repository<Role>.Delete(role.Id);
            return true;
        }

        public override bool RoleExists(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                throw new Exception("Role name is null or empty");
            var result = Repository<Role>.Get(d => d.RoleName == roleName);
            return result != null;
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            foreach (var username in usernames)
            {
                var user = Repository<User>.Get(c => c.Username == username);
                if (user == null)
                    continue;
                foreach (var roleName in roleNames)
                {
                    var role = Repository<Role>.Get(c => c.RoleName == roleName);
                    if (role == null)
                        continue;

                    var userinRole = new UserInRole
                    {
                        RoleId = role.Id,
                        UserId = user.Id
                    };
                    Repository<UserInRole>.Create(userinRole);
                }
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            foreach (var username in usernames)
            {
                var user = Repository<User>.Get(c => c.Username == username);
                if (user == null)
                    continue;
                foreach (var roleName in roleNames)
                {
                    var role = Repository<Role>.Get(c => c.RoleName == roleName);
                    if (role == null)
                        continue;

                    var userinRole = Repository<UserInRole>.Get(c => c.RoleId == role.Id && c.UserId == user.Id);
                    Repository<UserInRole>.Delete(userinRole.Id);
                }
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            var data = Repository<UserInRole>.GetMany(c => c.Role.RoleName == roleName).Select(c => c.User.Username);
            return data.ToArray();
        }

        public override string[] GetAllRoles()
        {
            var data = Repository<Role>.GetAll().Select(c => c.RoleName);
            return data.ToArray();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            string[] userSearch = { usernameToMatch };
            var users = Repository<UserInRole>.GetMany(c => c.Role.RoleName == roleName).Select(c => c.User.Username);
            return users.Intersect(userSearch).ToArray();
        }
    }
}

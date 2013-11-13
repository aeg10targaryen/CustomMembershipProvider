using System.Web.Security;

namespace MyMembership
{
    public abstract class MyRoleProvider : RoleProvider
    {
        public abstract override bool IsUserInRole(string username, string roleName);
        public abstract override string[] GetRolesForUser(string username);
        public abstract override void CreateRole(string roleName);
        public abstract override bool DeleteRole(string roleName, bool throwOnPopulatedRole);
        public abstract override bool RoleExists(string roleName);
        public abstract override void AddUsersToRoles(string[] usernames, string[] roleNames);
        public abstract override void RemoveUsersFromRoles(string[] usernames, string[] roleNames);
        public abstract override string[] GetUsersInRole(string roleName);
        public abstract override string[] GetAllRoles();
        public abstract override string[] FindUsersInRole(string roleName, string usernameToMatch);
    }
}

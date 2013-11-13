using System.Collections.Generic;
using System.Web.Security;
using Data.Models.User;

namespace MyMembership
{
    public abstract class MyUserProvider : MembershipProvider
    {
        public abstract bool CreateAccount(string firstName, string secondName, string lastName, string email, string password, int countryId, int phoneNumber, List<Role> roles);
        public abstract bool EditAccount(string userName);
        public abstract bool DeleteAccount(string userName);
        public abstract bool ChangePassword(string userName, string newPassword);
        public abstract string ResetPassword(string userName);
        public abstract bool ConfirmAccount(string accountConfirmationToken);
    }
}
 
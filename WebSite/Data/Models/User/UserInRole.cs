using System.ComponentModel.DataAnnotations.Schema;
using Data.Models.Base;

namespace Data.Models.User
{
    [Table("UserInRole")]
    public class UserInRole : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}

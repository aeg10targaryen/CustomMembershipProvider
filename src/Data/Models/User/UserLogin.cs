using System;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Models.Base;

namespace Data.Models.User
{
    [Table("UserLogin")]
    public class UserLogin : BaseEntity
    {
        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public string UserName { get; set; }

        public string IpAddress { get; set; }

        public DateTime ProcessDate { get; set; }

        public bool LoginSuccess { get; set; }
    }
}

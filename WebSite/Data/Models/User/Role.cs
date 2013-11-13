using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Models.Base;

namespace Data.Models.User
{
    [Table("Roles")]
    public class Role : BaseEntity
    {
        [Required]
        [MaxLength(25)]
        public string RoleName { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<UserInRole> UserInRoles { get; set; }
    }
}

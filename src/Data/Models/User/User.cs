using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Models.Base;
using Data.Models.General;

namespace Data.Models.User
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string SecondName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName 
        { 
            get
            {
                var name = FirstName + " " + SecondName;
                if(string.IsNullOrEmpty(SecondName))
                    name = name.TrimEnd(' ');
                return name + " " + LastName;
            }
        }

        [Required]
        [MaxLength(75)]
        public string EMail { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        [MaxLength(10)]
        public int? PhoneNumber { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<UserInRole> UserInRoles { get; set; }
        
        [ScaffoldColumn(false)]
        public virtual ICollection<UserLogin> UserLogins { get; set; }
    }
}

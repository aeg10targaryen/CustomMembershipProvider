using System.ComponentModel.DataAnnotations;
using Data.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.User
{
    [Table("PasswordQuestion")]
    public class PasswordQuestion : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [MaxLength(250)]
        public string QuestionText { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using Data.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Models.General;

namespace Data.Models.User
{
    [Table("LocalizedPasswordAnswer")]
    public class LocalizedPasswordAnswer : BaseEntity
    {
        public int PasswordAnswerId { get; set; }
        public virtual PasswordAnswer PasswordAnswer { get; set; }

        public int LangId { get; set; }
        public virtual Lang Lang { get; set; }

        [Required]
        [MaxLength(250)]
        public string LocalizedAnswerText { get; set; }
    }
}

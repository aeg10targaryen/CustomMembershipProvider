using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.User
{
    [Table("PasswordAnswer")]
    public class PasswordAnswer : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string AnswerText { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<LocalizedPasswordAnswer> LocalizedPasswordAnswers { get; set; }
    }
}

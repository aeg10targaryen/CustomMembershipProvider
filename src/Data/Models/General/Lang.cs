using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Models.Base;
using Data.Models.User;

namespace Data.Models.General
{
    [Table("Lang")]
    public class Lang : BaseEntity
    {
        [Required]
        [MaxLength(3)]
        public string LanguageCode { get; set; }

        [Required]
        [MaxLength(255)]
        public string LanguageImage { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<LocalizedLang> LocalizedLangs { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<LocalizedSpecialText> LocalizedSpecialTexts { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<LocalizedPasswordAnswer> LocalizedPasswordAnswers { get; set; }
    }
}

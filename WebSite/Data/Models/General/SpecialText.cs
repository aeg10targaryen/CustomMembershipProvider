using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data.Models.Base;

namespace Data.Models.General
{
    public class SpecialText : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string Text { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<LocalizedSpecialText> LocalizedSpecialTexts { get; set; }
    }
}

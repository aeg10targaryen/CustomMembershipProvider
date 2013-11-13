using System.ComponentModel.DataAnnotations;
using Data.Models.Base;

namespace Data.Models.General
{
    public class LocalizedSpecialText : BaseEntity
    {
        public int SpecialTextId { get; set; }
        public virtual SpecialText SpecialText { get; set; }

        public int LangId { get; set; }
        public virtual Lang Lang { get; set; }

        [Required]
        [MaxLength(1000)]
        public string LocalizedText { get; set; }
    }
}

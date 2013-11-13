using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Models.Base;

namespace Data.Models.General
{
    [Table("LocalizedLang")]
    public class LocalizedLang : BaseEntity
    {
        public int LangId { get; set; }
        public virtual Lang Lang { get; set; }

        [Required]
        [MaxLength(50)]
        public string LocalizedLangName { get; set; }
    }
}

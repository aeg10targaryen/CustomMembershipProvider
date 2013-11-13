using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Models.Base;

namespace Data.Models.General
{
    [Table("LocalizedCountry")]
    public class LocalizedCountry : BaseEntity
    {
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int LangId { get; set; }
        public virtual Lang Lang { get; set; }

        [Required]
        [MaxLength(50)]
        public string LocalizedCountryName { get; set; }
    }
}

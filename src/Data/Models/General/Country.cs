using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Models.Base;

namespace Data.Models.General
{
    [Table("Country")]
    public class Country : BaseEntity
    {
        [Required]
        [MaxLength(4)]
        public string CountryCode { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<User.User> Users { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<LocalizedCountry> LocalizedCountries { get; set; }
    }
}

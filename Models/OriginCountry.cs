using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    public partial class OriginCountry
    {
        public OriginCountry()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        //"CountryID")]
        public int CountryId { get; set; }
        [StringLength(200)]
        public string CountryName { get; set; } = null!;
        [StringLength(100)]
        public string? Description { get; set; }
        //"SectorId")]
        public int? SectorId { get; set; }

        [ForeignKey("SectorId")]
        [InverseProperty("OriginCountries")]
        public virtual Sector? Sector { get; set; } = null!;
        [InverseProperty("OriginCountry")]
        public virtual ICollection<Item>? Items { get; set; }
    }
}

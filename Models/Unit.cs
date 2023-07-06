using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    public partial class Unit
    {
        public Unit()
        {
            ItemUnits = new HashSet<ItemUnit>();
            Packagings = new HashSet<Packaging>();
            ProductPricings = new HashSet<ProductPricing>();
        }

        [Key]
        //"ID")]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [StringLength(20)]
        public string Abbreviation { get; set; } = null!;
        //"SectorId")]
        public int SectorId { get; set; }

        [ForeignKey("SectorId")]
        [InverseProperty("Units")]
        public virtual Sector Sector { get; set; } = null!;
        [InverseProperty("Unit")]
        public virtual ICollection<ItemUnit> ItemUnits { get; set; }
        [InverseProperty("Unit")]
        public virtual ICollection<Packaging> Packagings { get; set; }
        [InverseProperty("Unit")]
        public virtual ICollection<ProductPricing> ProductPricings { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    [Table("Packaging")]
    public partial class Packaging
    {
        public Packaging()
        {
            ProductPricings = new HashSet<ProductPricing>();
        }

        [Key]
        //"ID")]
        public int Id { get; set; }
        //"UnitID")]
        public int UnitId { get; set; }
        [StringLength(100)]
        public string Type { get; set; } = null!;
        //TypeName = "decimal(10, 2)")]
        public decimal Size { get; set; }
        //"SectorId")]
        public int SectorId { get; set; }

        [ForeignKey("SectorId")]
        [InverseProperty("Packagings")]
        public virtual Sector Sector { get; set; } = null!;
        [ForeignKey("UnitId")]
        [InverseProperty("Packagings")]
        public virtual Unit Unit { get; set; } = null!;
        [InverseProperty("Packaging")]
        public virtual ICollection<ProductPricing> ProductPricings { get; set; }
    }
}

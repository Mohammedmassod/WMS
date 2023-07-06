using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    [Table("ProductPricing")]
    [Index("ItemId", Name = "IX_ProductPricing_ItemID")]
    public partial class ProductPricing
    {
        [Key]
        //"ID")]
        public int Id { get; set; }
        //"ItemID")]
        public int ItemId { get; set; }
        //"UnitID")]
        public int UnitId { get; set; }
        //"PackagingID")]
        public int PackagingId { get; set; }
        //TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        //"SectorId")]
        public int SectorId { get; set; }

        [ForeignKey("ItemId")]
        [InverseProperty("ProductPricings")]
        public virtual Item Item { get; set; } = null!;
        [ForeignKey("PackagingId")]
        [InverseProperty("ProductPricings")]
        public virtual Packaging Packaging { get; set; } = null!;
        [ForeignKey("SectorId")]
        [InverseProperty("ProductPricings")]
        public virtual Sector Sector { get; set; } = null!;
        [ForeignKey("UnitId")]
        [InverseProperty("ProductPricings")]
        public virtual Unit Unit { get; set; } = null!;
    }
}

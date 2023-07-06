using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    public partial class Item
    {
        public Item()
        {
            ItemUnits = new HashSet<ItemUnit>();
            ProductPricings = new HashSet<ProductPricing>();
            StockItems = new HashSet<StockItem>();
            StorageConditions = new HashSet<StorageCondition>();
        }

        [Key]
        //"ItemID")]
        public int ItemId { get; set; }
        [StringLength(200)]
        public string ItemName { get; set; } = null!;
        [StringLength(250)]
        public string? Description { get; set; }
        [StringLength(20)]
        public string? Barcode { get; set; }
        //TypeName = "decimal(10, 2)")]
        public decimal? MinLimit { get; set; }
        //TypeName = "decimal(10, 2)")]
        public decimal? MaxLimit { get; set; }
        [StringLength(100)]
        public string UnitName { get; set; } = null!;
        public int? AvailableQuantity { get; set; }
        public int? SoldQuantity { get; set; }
        public int? ProducedQuantity { get; set; }
        public int? ComingQuantity { get; set; }
        //TypeName = "decimal(10, 2)")]
        public decimal? Length { get; set; }
        //TypeName = "decimal(10, 2)")]
        public decimal? Width { get; set; }
        //TypeName = "decimal(10, 2)")]
        public decimal? Height { get; set; }
        [StringLength(200)]
        public string Status { get; set; } = null!;
        public double ItemSize { get; set; }
        //TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(200)]
        public string? CreatedBy { get; set; }
        //"OriginCountryID")]
        public int? OriginCountryId { get; set; }
        //"ItemGroupID")]
        public int? ItemGroupId { get; set; }
        //"TypeID")]
        public int? TypeId { get; set; }
        //"StorageConditionID")]
        public int? StorageConditionId { get; set; }
        //"SectorId")]
        public int SectorId { get; set; }

        [ForeignKey("ItemGroupId")]
        [InverseProperty("Items")]
        public virtual ItemGroup? ItemGroup { get; set; }
        [ForeignKey("OriginCountryId")]
        [InverseProperty("Items")]
        public virtual OriginCountry? OriginCountry { get; set; }
        [ForeignKey("SectorId")]
        [InverseProperty("Items")]
        public virtual Sector Sector { get; set; } = null!;
        [ForeignKey("TypeId")]
        [InverseProperty("Items")]
        public virtual ItemType? Type { get; set; }
        [InverseProperty("Item")]
        public virtual ICollection<ItemUnit> ItemUnits { get; set; }
        [InverseProperty("Item")]
        public virtual ICollection<ProductPricing> ProductPricings { get; set; }
        [InverseProperty("Item")]
        public virtual ICollection<StockItem> StockItems { get; set; }
        [InverseProperty("Item")]
        public virtual ICollection<StorageCondition> StorageConditions { get; set; }
    }
}

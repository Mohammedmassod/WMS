using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    [Table("InventoryMonitoring")]
    public partial class InventoryMonitoring
    {
        [Key]
        //"ID")]
        public int Id { get; set; }
        //TypeName = "date")]
        public DateTime Date { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string ItemName { get; set; } = null!;
        public int Quantity { get; set; }
        [StringLength(100)]
        public string TypePackaging { get; set; } = null!;
        //TypeName = "decimal(18, 2)")]
        public decimal UnitStrength { get; set; }
        public int CurrentBalance { get; set; }
        //"MovementID")]
        public string? GovernorateName { get; set; }
        public string? DirectorateName { get; set; }
        public int MovementId { get; set; }
        //"ItemID")]
        public int ItemId { get; set; }
        //"StoreID")]
        public int StoreId { get; set; }
        //"OfficeID")]
        public int OfficeId { get; set; }
        //"SectorId")]
        public int SectorId { get; set; }

        [ForeignKey("MovementId")]
        [InverseProperty("InventoryMonitorings")]
        public virtual InventoryMovement Movement { get; set; } = null!;
        [ForeignKey("OfficeId")]
        [InverseProperty("InventoryMonitorings")]
        public virtual Office Office { get; set; } = null!;
        [ForeignKey("SectorId")]
        [InverseProperty("InventoryMonitorings")]
        public virtual Sector Sector { get; set; } = null!;
        [ForeignKey("StoreId")]
        [InverseProperty("InventoryMonitorings")]
        public virtual Store Store { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    public partial class Store
    {
        public Store()
        {
            InventoryMonitorings = new HashSet<InventoryMonitoring>();
            Owners = new HashSet<Owner>();
            PackingStores = new HashSet<PackingStore>();
            StockItems = new HashSet<StockItem>();
            Storages = new HashSet<Storage>();
        }

        [Key]
        //"StoreID")]
        public int StoreId { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string StoreName { get; set; } = null!;
        [StringLength(200)]
        [Unicode(false)]
        public string Governorate { get; set; } = null!;
        [StringLength(200)]
        [Unicode(false)]
        public string District { get; set; } = null!;
        [StringLength(200)]
        [Unicode(false)]
        public string Street { get; set; } = null!;
        [StringLength(200)]
        [Unicode(false)]
        public string NextTo { get; set; } = null!;
        [StringLength(200)]
        [Unicode(false)]
        public string Status { get; set; } = null!;
        [StringLength(200)]
        [Unicode(false)]
        public string? StoreType { get; set; }
        //"RequestID")]
        public int RequestId { get; set; }
        //"OfficeID")]
        public int OfficeId { get; set; }
        //"TraderID")]
        public int TraderId { get; set; }

        [ForeignKey("OfficeId")]
        [InverseProperty("Stores")]
        public virtual Office Office { get; set; } = null!;
        [ForeignKey("RequestId")]
        [InverseProperty("Stores")]
        public virtual Request Request { get; set; } = null!;
        [ForeignKey("TraderId")]
        [InverseProperty("Stores")]
        public virtual Trader Trader { get; set; } = null!;
        [InverseProperty("Store")]
        public virtual ICollection<InventoryMonitoring> InventoryMonitorings { get; set; }
        [InverseProperty("Store")]
        public virtual ICollection<Owner> Owners { get; set; }
        [InverseProperty("Store")]
        public virtual ICollection<PackingStore> PackingStores { get; set; }
        [InverseProperty("Store")]
        public virtual ICollection<StockItem> StockItems { get; set; }
        [InverseProperty("Store")]
        public virtual ICollection<Storage> Storages { get; set; }
    }
}

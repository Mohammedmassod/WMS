using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    [Table("PackingStore")]
    public partial class PackingStore
    {
        [Key]
        //"PackingStoreID")]
        public int PackingStoreId { get; set; }
        public int ProductionLineCount { get; set; }
        public int ProductionLineCapacity { get; set; }
        //"RequestID")]
        public int RequestId { get; set; }
        //"StoreID")]
        public int StoreId { get; set; }
        //"OfficeID")]
        public int OfficeId { get; set; }
        //"TraderID")]
        public int TraderId { get; set; }

        [ForeignKey("OfficeId")]
        [InverseProperty("PackingStores")]
        public virtual Office Office { get; set; } = null!;
        [ForeignKey("RequestId")]
        [InverseProperty("PackingStores")]
        public virtual Request Request { get; set; } = null!;
        [ForeignKey("StoreId")]
        [InverseProperty("PackingStores")]
        public virtual Store Store { get; set; } = null!;
        [ForeignKey("TraderId")]
        [InverseProperty("PackingStores")]
        public virtual Trader Trader { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    [Table("StockItem")]
    public partial class StockItem
    {
        [Key]
        //"StockItemID")]
        public int StockItemId { get; set; }
        //"ItemID")]
        public int ItemId { get; set; }
        //"StoreID")]
        public int StoreId { get; set; }
        public int Quantity { get; set; }
        //TypeName = "date")]
        public DateTime ProductionDate { get; set; }
        //TypeName = "date")]
        public DateTime ExpirationDate { get; set; }
        //TypeName = "datetime")]
        public DateTime SystemDate { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string TypeStockItem { get; set; } = null!;

        [ForeignKey("ItemId")]
        [InverseProperty("StockItems")]
        public virtual Item Item { get; set; } = null!;
        [ForeignKey("StoreId")]
        [InverseProperty("StockItems")]
        public virtual Store Store { get; set; } = null!;
    }
}

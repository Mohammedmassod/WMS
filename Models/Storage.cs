using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    [Table("Storage")]
    public partial class Storage
    {
        [Key]
        //"StorageID")]
        public int StorageId { get; set; }
        //"Building_Type")]
        [StringLength(200)]
        [Unicode(false)]
        public string BuildingType { get; set; } = null!;
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        //"Number_Open")]
        public int NumberOpen { get; set; }
        public int StorageVolume { get; set; }
        public int StorageCapacity { get; set; }
        //"Size_Item")]
        public double SizeItem { get; set; }
        //"Item_Storage_Conditions")]
        [StringLength(200)]
        [Unicode(false)]
        public string ItemStorageConditions { get; set; } = null!;
        //"Store_Storage_Conditions")]
        [StringLength(200)]
        [Unicode(false)]
        public string StoreStorageConditions { get; set; } = null!;
        //"RequestID")]
        public int RequestId { get; set; }
        //"OfficeID")]
        public int OfficeId { get; set; }
        //"TraderID")]
        public int TraderId { get; set; }
        //"StoreID")]
        public int StoreId { get; set; }

        [ForeignKey("OfficeId")]
        [InverseProperty("Storages")]
        public virtual Office Office { get; set; } = null!;
        [ForeignKey("RequestId")]
        [InverseProperty("Storages")]
        public virtual Request Request { get; set; } = null!;
        [ForeignKey("StoreId")]
        [InverseProperty("Storages")]
        public virtual Store Store { get; set; } = null!;
        [ForeignKey("TraderId")]
        [InverseProperty("Storages")]
        public virtual Trader Trader { get; set; } = null!;
    }
}

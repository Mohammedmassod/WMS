using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    public partial class ItemUnit
    {
        [Key]
        //"ItemID")]
        public int ItemId { get; set; }
        [Key]
        //"UnitID")]
        public int UnitId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("ItemId")]
        [InverseProperty("ItemUnits")]
        public virtual Item Item { get; set; } = null!;
        [ForeignKey("UnitId")]
        [InverseProperty("ItemUnits")]
        public virtual Unit Unit { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    public partial class ItemType
    {
        public ItemType()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        //"TypeID")]
        public int TypeId { get; set; }
        [StringLength(200)]
        public string TypeName { get; set; } = null!;
        [StringLength(100)]
        public string? Description { get; set; }
        public bool Status { get; set; }
        //"SectorId")]
        public int SectorId { get; set; }

        [ForeignKey("SectorId")]
        [InverseProperty("ItemTypes")]
        public virtual Sector Sector { get; set; } = null!;
        [InverseProperty("Type")]
        public virtual ICollection<Item> Items { get; set; }
    }
}

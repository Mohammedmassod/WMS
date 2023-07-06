using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    public partial class ItemGroup
    {
        public ItemGroup()
        {
            //InverseParentGroup = new HashSet<ItemGroup>();
            //Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        [StringLength(200)]
        public string GroupName { get; set; } = null!;
        [StringLength(100)]
        public string? Description { get; set; }
        public bool Status { get; set; }
        [Column("ranking")]
        public int? Ranking { get; set; }
        //"SectorId")]
        public int SectorId { get; set; }
        //"ParentGroupID")]
        public int? ParentGroupId { get; set; }

        [ForeignKey("ParentGroupId")]
        [InverseProperty("InverseParentGroup")]
        public virtual ItemGroup? ParentGroup { get; set; }
        [ForeignKey("SectorId")]
        [InverseProperty("ItemGroups")]
        public virtual Sector? Sector { get; set; } = null!;
        [InverseProperty("ParentGroup")]
        public virtual ICollection<ItemGroup>? InverseParentGroup { get; set; }
        [InverseProperty("ItemGroup")]
        public virtual ICollection<Item>? Items { get; set; }
    }
}

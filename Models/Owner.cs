using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    [Table("Owner")]
    public partial class Owner
    {
        [Key]
        //"OwnerID")]
        public int OwnerId { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string OwnerName { get; set; } = null!;
        [StringLength(200)]
        [Unicode(false)]
        public string? Address { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? Phone { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string? Email { get; set; }
        //"StoreID")]
        public int StoreId { get; set; }

        [ForeignKey("StoreId")]
        [InverseProperty("Owners")]
        public virtual Store Store { get; set; } = null!;
    }
}

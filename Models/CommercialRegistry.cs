using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    [Table("CommercialRegistry")]
    public partial class CommercialRegistry
    {
        [Key]
        //"CommercialRegistryID")]
        public int CommercialRegistryId { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string RegistryNumber { get; set; } = null!;
        //TypeName = "date")]
        public DateTime IssueDate { get; set; }
        //TypeName = "date")]
        public DateTime ExpirationDate { get; set; }
        //"Registry_Type")]
        [StringLength(200)]
        [Unicode(false)]
        public string RegistryType { get; set; } = null!;
        //"Registry_Category")]
        [StringLength(200)]
        [Unicode(false)]
        public string RegistryCategory { get; set; } = null!;
        //"Owner_Name")]
        [StringLength(200)]
        [Unicode(false)]
        public string OwnerName { get; set; } = null!;
        //"Registry_Status")]
        public bool RegistryStatus { get; set; }
        //"TraderID")]
        public int TraderId { get; set; }
        //"OfficeID")]
        public int OfficeId { get; set; }

        [ForeignKey("TraderId")]
        [InverseProperty("CommercialRegistries")]
        public virtual Trader Trader { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    [Table("TaxID")]
    [Index("TaxIdNumber", Name = "UQ__TaxID__14068BFD276D7E67", IsUnique = true)]
    public partial class TaxId
    {
        [Key]
        //"TaxID")]
        public int TaxId1 { get; set; }
        //"Tax_ID_Number")]
        public int TaxIdNumber { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string Issuer { get; set; } = null!;
        //"Date_Last_Renewal", TypeName = "date")]
        public DateTime DateLastRenewal { get; set; }
        //"TraderID")]
        public int TraderId { get; set; }
        //"OfficeID")]
        public int OfficeId { get; set; }

        [ForeignKey("OfficeId")]
        [InverseProperty("TaxIds")]
        public virtual Office Office { get; set; } = null!;
        [ForeignKey("TraderId")]
        [InverseProperty("TaxIds")]
        public virtual Trader Trader { get; set; } = null!;
    }
}

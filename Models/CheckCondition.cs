using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    public partial class CheckCondition
    {
        [Key]
        //"CheckConditionID")]
        public int CheckConditionId { get; set; }
        //TypeName = "date")]
        public DateTime CheckDate { get; set; }
        //"DPSAR")]
        public bool Dpsar { get; set; }
        //"SLPR")]
        public bool Slpr { get; set; }
        //"ASPGP")]
        public bool Aspgp { get; set; }
        //"VCA")]
        public bool Vca { get; set; }
        //"CDP")]
        public bool Cdp { get; set; }
        //"IFR")]
        public bool Ifr { get; set; }
        //"IVEE")]
        public bool Ivee { get; set; }
        //"HCSW")]
        public bool Hcsw { get; set; }
        //"REFE")]
        public int Refe { get; set; }
        //"TR4")]
        public bool Tr4 { get; set; }
        //"TMD")]
        public bool Tmd { get; set; }
        //"LRC")]
        public bool Lrc { get; set; }
        //"ARS")]
        public bool Ars { get; set; }
        //"SSI")]
        public bool Ssi { get; set; }
        //"TVP", TypeName = "money")]
        public decimal Tvp { get; set; }
        //"LicenseID")]
        public string? GovernorateName { get; set; }
        public string? DirectorateName { get; set; }
        public int LicenseId { get; set; }
        //"RequestID")]
        public int RequestId { get; set; }
        //"OfficeID")]
        public int OfficeId { get; set; }
        //"TraderID")]
        public int TraderId { get; set; }

        [ForeignKey("LicenseId")]
        [InverseProperty("CheckConditions")]
        public virtual RestrictedLicense License { get; set; } = null!;
        [ForeignKey("OfficeId")]
        [InverseProperty("CheckConditions")]
        public virtual Office Office { get; set; } = null!;
        [ForeignKey("RequestId")]
        [InverseProperty("CheckConditions")]
        public virtual Request Request { get; set; } = null!;
        [ForeignKey("TraderId")]
        [InverseProperty("CheckConditions")]
        public virtual Trader Trader { get; set; } = null!;
    }
}

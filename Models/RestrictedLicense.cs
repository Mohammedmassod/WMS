using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    public partial class RestrictedLicense
    {
        public RestrictedLicense()
        {
            CheckConditions = new HashSet<CheckCondition>();
        }

        [Key]
        //"LicenseID")]
        public int LicenseId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string LicenseNumber { get; set; } = null!;
        //TypeName = "date")]
        public DateTime IssueDate { get; set; }
        //TypeName = "date")]
        public DateTime ExpirationDate { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string Status { get; set; } = null!;
        //"RequestID")]
        public int RequestId { get; set; }
        //"OfficeID")]
        public int OfficeId { get; set; }
        //"TraderID")]
        public int TraderId { get; set; }

        [ForeignKey("OfficeId")]
        [InverseProperty("RestrictedLicenses")]
        public virtual Office Office { get; set; } = null!;
        [ForeignKey("RequestId")]
        [InverseProperty("RestrictedLicenses")]
        public virtual Request Request { get; set; } = null!;
        [ForeignKey("TraderId")]
        [InverseProperty("RestrictedLicenses")]
        public virtual Trader Trader { get; set; } = null!;
        [InverseProperty("License")]
        public virtual ICollection<CheckCondition> CheckConditions { get; set; }
    }
}

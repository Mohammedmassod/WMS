using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    public partial class Request
    {
        public Request()
        {
            AttachedDocuments = new HashSet<AttachedDocument>();
            CheckConditions = new HashSet<CheckCondition>();
            Invoices = new HashSet<Invoice>();
            PackingStores = new HashSet<PackingStore>();
            PaymentReceipts = new HashSet<PaymentReceipt>();
            RestrictedLicenses = new HashSet<RestrictedLicense>();
            Storages = new HashSet<Storage>();
            Stores = new HashSet<Store>();
        }

        [Key]
        //"RequestID")]
        public int RequestId { get; set; }
        //TypeName = "date")]
        public DateTime RequestDate { get; set; }
        public int RequestStatus { get; set; }
        //"Stor_Mode")]
        [StringLength(200)]
        [Unicode(false)]
        public string StorMode { get; set; } = null!;
        //"Stor_Type")]
        [StringLength(200)]
        [Unicode(false)]
        public string StorType { get; set; } = null!;
        //"TraderID")]
        public string? GovernorateName { get; set; }
        public string? DirectorateName { get; set; }
        public int TraderId { get; set; }
        //"OfficeID")]
        public int OfficeId { get; set; }
        public bool FeeWaived { get; set; }

        [ForeignKey("OfficeId")]
        [InverseProperty("Requests")]
        public virtual Office? Office { get; set; } = null!;
        [ForeignKey("TraderId")]
        [InverseProperty("Requests")]
        public virtual Trader? Trader { get; set; } = null!;
        [InverseProperty("Request")]
        public virtual ICollection<AttachedDocument> AttachedDocuments { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<CheckCondition> CheckConditions { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<Invoice> Invoices { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<PackingStore> PackingStores { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<PaymentReceipt> PaymentReceipts { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<RestrictedLicense> RestrictedLicenses { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<Storage> Storages { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<Store> Stores { get; set; }
    }
}

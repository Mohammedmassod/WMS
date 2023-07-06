using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    [Index("NumberId", Name = "UQ__Traders__FF1D98271D41B72A", IsUnique = true)]
    public partial class Trader
    {
        public Trader()
        {
            CheckConditions = new HashSet<CheckCondition>();
            CommercialRegistries = new HashSet<CommercialRegistry>();
            Invoices = new HashSet<Invoice>();
            PackingStores = new HashSet<PackingStore>();
            PaymentReceipts = new HashSet<PaymentReceipt>();
            Requests = new HashSet<Request>();
            RestrictedLicenses = new HashSet<RestrictedLicense>();
            Storages = new HashSet<Storage>();
            Stores = new HashSet<Store>();
            TaxIds = new HashSet<TaxId>();
        }

        [Key]
        //"TraderID")]
        public int TraderId { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string TraderName { get; set; } = null!;
        //"Number_ID")]
        public int NumberId { get; set; }
        //"Type_ID")]
        [StringLength(200)]
        [Unicode(false)]
        public string TypeId { get; set; } = null!;
        [StringLength(200)]
        [Unicode(false)]
        public string Nationality { get; set; } = null!;
        //"Issuance_Date_ID", TypeName = "date")]
        public DateTime IssuanceDateId { get; set; }
        //"Issuing_Authority_ID")]
        [StringLength(200)]
        [Unicode(false)]
        public string IssuingAuthorityId { get; set; } = null!;
        //"Status_ID")]
        public bool StatusId { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string Phone { get; set; } = null!;
        //"OfficeID")]
        public int OfficeId { get; set; }
        //"SectorId")]
        public int SectorId { get; set; }

        [ForeignKey("OfficeId")]
        [InverseProperty("Traders")]
        public virtual Office? Office { get; set; } = null!;
        [ForeignKey("SectorId")]
        [InverseProperty("Traders")]
        public virtual Sector? Sector { get; set; } = null!;
        [InverseProperty("Trader")]
        public virtual ICollection<CheckCondition> CheckConditions { get; set; }
        [InverseProperty("Trader")]
        public virtual ICollection<CommercialRegistry> CommercialRegistries { get; set; }
        [InverseProperty("Trader")]
        public virtual ICollection<Invoice> Invoices { get; set; }
        [InverseProperty("Trader")]
        public virtual ICollection<PackingStore> PackingStores { get; set; }
        [InverseProperty("Trader")]
        public virtual ICollection<PaymentReceipt> PaymentReceipts { get; set; }
        [InverseProperty("Trader")]
        public virtual ICollection<Request> Requests { get; set; }
        [InverseProperty("Trader")]
        public virtual ICollection<RestrictedLicense> RestrictedLicenses { get; set; }
        [InverseProperty("Trader")]
        public virtual ICollection<Storage> Storages { get; set; }
        [InverseProperty("Trader")]
        public virtual ICollection<Store> Stores { get; set; }
        [InverseProperty("Trader")]
        public virtual ICollection<TaxId> TaxIds { get; set; }
    }
}

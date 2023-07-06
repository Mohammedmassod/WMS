using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    public partial class Office
    {
        public Office()
        {
            CheckConditions = new HashSet<CheckCondition>();
            InventoryMonitorings = new HashSet<InventoryMonitoring>();
            InvoiceTypes = new HashSet<InvoiceType>();
            Invoices = new HashSet<Invoice>();
            PackingStores = new HashSet<PackingStore>();
            PaymentReceipts = new HashSet<PaymentReceipt>();
            Requests = new HashSet<Request>();
            RestrictedLicenses = new HashSet<RestrictedLicense>();
            Storages = new HashSet<Storage>();
            Stores = new HashSet<Store>();
            TaxIds = new HashSet<TaxId>();
            Traders = new HashSet<Trader>();
            Users = new HashSet<Users>();

        }

        [Key]
        //"OfficeId")]
        public int OfficeId { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string OfficeName { get; set; } = null!;
        [StringLength(200)]
        [Unicode(false)]
        public string Address { get; set; } = null!;
        //"SectorId")]
        public int? GovernorateId { get; set; }
        public virtual Governorate Governorate { get; set; }
        public int? DirectorateId { get; set; }
        public virtual Directorate Directorate { get; set; }
        public int SectorId { get; set; }

        [ForeignKey("SectorId")]
        [InverseProperty("Offices")]
        public virtual Sector? Sector { get; set; } = null!;
        [InverseProperty("Office")]
        public virtual ICollection<CheckCondition> CheckConditions { get; set; }
        [InverseProperty("Office")]
        public virtual ICollection<InventoryMonitoring> InventoryMonitorings { get; set; }
        [InverseProperty("Office")]
        public virtual ICollection<InvoiceType> InvoiceTypes { get; set; }
        [InverseProperty("Office")]
        public virtual ICollection<Invoice> Invoices { get; set; }
        [InverseProperty("Office")]
        public virtual ICollection<PackingStore> PackingStores { get; set; }
        [InverseProperty("Office")]
        public virtual ICollection<PaymentReceipt> PaymentReceipts { get; set; }
        [InverseProperty("Office")]
        public virtual ICollection<Request> Requests { get; set; }
        [InverseProperty("Office")]
        public virtual ICollection<RestrictedLicense> RestrictedLicenses { get; set; }
        [InverseProperty("Office")]
        public virtual ICollection<Storage> Storages { get; set; }
        [InverseProperty("Office")]
        public virtual ICollection<Store> Stores { get; set; }
        [InverseProperty("Office")]
        public virtual ICollection<TaxId> TaxIds { get; set; }
        [InverseProperty("Office")]
        public virtual ICollection<Trader> Traders { get; set; }
        public virtual ICollection<Users> Users { get; set; }

    }
}

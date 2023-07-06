using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    public partial class InvoiceType
    {
        public InvoiceType()
        {
            Invoices = new HashSet<Invoice>();
            PaymentReceipts = new HashSet<PaymentReceipt>();
        }

        [Key]
        //"InvoiceTypeID")]
        public int InvoiceTypeId { get; set; }
        [StringLength(200)]
        public string TypeName { get; set; } = null!;
        //TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        [StringLength(200)]
        public string Status { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string Description { get; set; } = null!;
        //"OfficeID")]
        public int OfficeId { get; set; }

        [ForeignKey("OfficeId")]
        [InverseProperty("InvoiceTypes")]
        public virtual Office Office { get; set; } = null!;
        [InverseProperty("InvoiceType")]
        public virtual ICollection<Invoice> Invoices { get; set; }
        [InverseProperty("InvoiceType")]
        public virtual ICollection<PaymentReceipt> PaymentReceipts { get; set; }
    }
}

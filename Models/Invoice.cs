using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            PaymentReceipts = new HashSet<PaymentReceipt>();
        }

        [Key]
        //"InvoiceID")]
        public int InvoiceId { get; set; }
        //TypeName = "date")]
        public DateTime InvoiceDate { get; set; }
        //TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string PaymentStatus { get; set; } = null!;
        //TypeName = "date")]
        public DateTime PaymentDate { get; set; }
        //"InvoiceTypeID")]
        public int InvoiceTypeId { get; set; }
        //"RequestID")]
        public int RequestId { get; set; }
        //"OfficeID")]
        public int OfficeId { get; set; }
        //"TraderID")]
        public int TraderId { get; set; }

        [ForeignKey("InvoiceTypeId")]
        [InverseProperty("Invoices")]
        public virtual InvoiceType InvoiceType { get; set; } = null!;
        [ForeignKey("OfficeId")]
        [InverseProperty("Invoices")]
        public virtual Office Office { get; set; } = null!;
        [ForeignKey("RequestId")]
        [InverseProperty("Invoices")]
        public virtual Request Request { get; set; } = null!;
        [ForeignKey("TraderId")]
        [InverseProperty("Invoices")]
        public virtual Trader Trader { get; set; } = null!;
        [InverseProperty("Invoice")]
        public virtual ICollection<PaymentReceipt> PaymentReceipts { get; set; }
    }
}

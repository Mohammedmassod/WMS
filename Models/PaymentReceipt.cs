using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    public partial class PaymentReceipt
    {
        [Key]
        //"ReceiptID")]
        public int ReceiptId { get; set; }
        //TypeName = "date")]
        public DateTime PaymentDate { get; set; }
        //TypeName = "decimal(10, 2)")]
        public decimal PaymentAmount { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string PaymentMethod { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string PaymentReference { get; set; } = null!;
        //"InvoiceID")]
        public int InvoiceId { get; set; }
        //"InvoiceTypeID")]
        public int InvoiceTypeId { get; set; }
        //"RequestID")]
        public int RequestId { get; set; }
        //"OfficeID")]
        public int OfficeId { get; set; }
        //"TraderID")]
        public int TraderId { get; set; }

        [ForeignKey("InvoiceId")]
        [InverseProperty("PaymentReceipts")]
        public virtual Invoice Invoice { get; set; } = null!;
        [ForeignKey("InvoiceTypeId")]
        [InverseProperty("PaymentReceipts")]
        public virtual InvoiceType InvoiceType { get; set; } = null!;
        [ForeignKey("OfficeId")]
        [InverseProperty("PaymentReceipts")]
        public virtual Office Office { get; set; } = null!;
        [ForeignKey("RequestId")]
        [InverseProperty("PaymentReceipts")]
        public virtual Request Request { get; set; } = null!;
        [ForeignKey("TraderId")]
        [InverseProperty("PaymentReceipts")]
        public virtual Trader Trader { get; set; } = null!;
    }
}

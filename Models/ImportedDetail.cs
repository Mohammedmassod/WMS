using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    public partial class ImportedDetail
    {
        [Key]
        //"ID")]
        public int Id { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string Status { get; set; } = null!;
        [StringLength(200)]
        [Unicode(false)]
        public string ContractType { get; set; } = null!;
        //TypeName = "date")]
        public DateTime Date { get; set; }
        //TypeName = "date")]
        public DateTime ProductionDate { get; set; }
        //TypeName = "date")]
        public DateTime ExpirationDate { get; set; }
        public int InvoiceNumber { get; set; }
        //"MonitoringID")]
        public int MonitoringId { get; set; }

        [ForeignKey("MonitoringId")]
        [InverseProperty("ImportedDetails")]
        public virtual InventoryMovement Monitoring { get; set; } = null!;
    }
}

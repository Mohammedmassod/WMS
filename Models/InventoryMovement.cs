using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    public partial class InventoryMovement
    {
        public InventoryMovement()
        {
            ImportedDetails = new HashSet<ImportedDetail>();
            InventoryMonitorings = new HashSet<InventoryMonitoring>();
        }

        [Key]
        //"ID")]
        public int Id { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string MovementName { get; set; } = null!;
        [Required]
        public bool? Status { get; set; }
        //"SectorId")]
        public int SectorId { get; set; }

        [ForeignKey("SectorId")]
        [InverseProperty("InventoryMovements")]
        public virtual Sector Sector { get; set; } = null!;
        [InverseProperty("Monitoring")]
        public virtual ICollection<ImportedDetail> ImportedDetails { get; set; }
        [InverseProperty("Movement")]
        public virtual ICollection<InventoryMonitoring> InventoryMonitorings { get; set; }
    }
}

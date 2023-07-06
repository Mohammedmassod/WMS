using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    public partial class StorageCondition
    {
        [Key]
        //"StorageConditionID")]
        public int StorageConditionId { get; set; }
        public bool SpeciesStorage { get; set; }
        //TypeName = "decimal(10, 2)")]
        public decimal IlluminationLevel { get; set; }
        public bool MenusAndLightSlots { get; set; }
        //TypeName = "decimal(10, 2)")]
        public decimal HumidityLevel { get; set; }
        //TypeName = "decimal(10, 2)")]
        public decimal HeatLevel { get; set; }
        [StringLength(200)]
        public string StorageType { get; set; } = null!;
        //"ItemID")]
        public int ItemId { get; set; }

        [ForeignKey("ItemId")]
        [InverseProperty("StorageConditions")]
        public virtual Item Item { get; set; } = null!;
    }
}

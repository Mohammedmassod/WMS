using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    public partial class Sector
    {
        public Sector()
        {
            //InventoryMonitorings = new HashSet<InventoryMonitoring>();
            //InventoryMovements = new HashSet<InventoryMovement>();
            //ItemGroups = new HashSet<ItemGroup>();
            //ItemTypes = new HashSet<ItemType>();
            //Items = new HashSet<Item>();
            //Offices = new HashSet<Office>();
            //OriginCountries = new HashSet<OriginCountry>();
            //Packagings = new HashSet<Packaging>();
            //ProductPricings = new HashSet<ProductPricing>();
            //Traders = new HashSet<Trader>();
            //Units = new HashSet<Unit>();
        }

        [Key]
        //"SectorId")]
        public int SectorId { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string SectorName { get; set; } = null!;
        [StringLength(200)]
        [Unicode(false)]
        public string Discription { get; set; } = null!;
        public bool Status{ get; set; } 
        [InverseProperty("Sector")]
        public virtual ICollection<InventoryMonitoring> InventoryMonitorings { get; set; }
        [InverseProperty("Sector")]
        public virtual ICollection<InventoryMovement> InventoryMovements { get; set; }
        [InverseProperty("Sector")]
        public virtual ICollection<ItemGroup> ItemGroups { get; set; }
        [InverseProperty("Sector")]
        public virtual ICollection<ItemType> ItemTypes { get; set; }
        [InverseProperty("Sector")]
        public virtual ICollection<Item> Items { get; set; }
        [InverseProperty("Sector")]
        public virtual ICollection<Office> Offices { get; set; }
        [InverseProperty("Sector")]
        public virtual ICollection<OriginCountry> OriginCountries { get; set; }
        [InverseProperty("Sector")]
        public virtual ICollection<Packaging> Packagings { get; set; }
        [InverseProperty("Sector")]
        public virtual ICollection<ProductPricing> ProductPricings { get; set; }
        [InverseProperty("Sector")]
        public virtual ICollection<Trader> Traders { get; set; }
        [InverseProperty("Sector")]
        public virtual ICollection<Unit> Units { get; set; }
    }
}

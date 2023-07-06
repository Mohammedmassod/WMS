using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WMS.Models;

namespace WMS.Data
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }
        public virtual DbSet<Users>? Userss { get; set; }
        public virtual DbSet<Roles>? Roless { get; set; }
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<Directorate> Directorates { get; set; }
        public virtual DbSet<AttachedDocument>? AttachedDocuments { get; set; }
        public virtual DbSet<CheckCondition>? CheckConditions { get; set; }
        public virtual DbSet<CommercialRegistry>? CommercialRegistries { get; set; }
        public virtual DbSet<ImportedDetail>? ImportedDetails { get; set; }
        public virtual DbSet<InventoryMonitoring>? InventoryMonitorings { get; set; }
        public virtual DbSet<InventoryMovement>? InventoryMovements { get; set; }
        public virtual DbSet<Invoice>? Invoices { get; set; }
        public virtual DbSet<InvoiceType>? InvoiceTypes { get; set; }
        public virtual DbSet<Item>? Items { get; set; }
        public virtual DbSet<ItemGroup> ItemGroups { get; set; }
        public virtual DbSet<ItemType>? ItemTypes { get; set; }
        public virtual DbSet<ItemUnit>? ItemUnits { get; set; }
        public virtual DbSet<Office>? Offices { get; set; }
        public virtual DbSet<OriginCountry>? OriginCountries { get; set; }
        public virtual DbSet<Owner>? Owners { get; set; }
        public virtual DbSet<Packaging>? Packagings { get; set; }
        public virtual DbSet<PackingStore>? PackingStores { get; set; }
        public virtual DbSet<PaymentReceipt>? PaymentReceipts { get; set; }
        public virtual DbSet<ProductPricing>? ProductPricings { get; set; }
        public virtual DbSet<Request>? Requests { get; set; }
        public virtual DbSet<RestrictedLicense>? RestrictedLicenses { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<StockItem>? StockItems { get; set; }
        public virtual DbSet<Storage>? Storages { get; set; }
        public virtual DbSet<StorageCondition>? StorageConditions { get; set; }
        public virtual DbSet<Store>? Stores { get; set; }
        public virtual DbSet<TaxId>? TaxIds { get; set; }
        public virtual DbSet<Trader>? Traders { get; set; }
        public virtual DbSet<Unit>? Units { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            builder.UseCollation("Arabic_CI_AS");

            builder.Entity<Sector>().HasData(new Sector()
            {
                SectorId = 1,
                SectorName = "صنعاء",
                Discription = "SuperAdmin",


            });
            builder.Entity<Governorate>().HasData(new Governorate()
            {
                GovernorateId = 1,
                GovernorateName = "صنعاء",


            });
            builder.Entity<Directorate>().HasData(new Directorate()
            {
                DirectorateId = 1,
                DirectorateName = "الامانة",
                GovernorateId = 1,


            });
            builder.Entity<Office>().HasData(new Office()
            {
                OfficeId = 1,
                OfficeName = "الغرفة التجارية",
                Address = "الحصبة",
                GovernorateId = 1,
                DirectorateId=1,
                SectorId = 1,
               

            });
            var hasher = new PasswordHasher<Users>();

            builder.Entity<Users>().HasData(new Users()
            {
                Id = "4a2e1650-21bd-4e67-832e-2e99c267a2e4",
                Name = "رئيس مجلس الادارة",
                UserName = "SuperAdmin",
                Email = "Admin@gmail.com",
                PhoneNumber = "778877887",
                IsClient = true,
                PasswordHash = hasher.HashPassword(null, "Admin123"),
                NormalizedUserName = "SUPERADMIN",
                Pass = "Admin123",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                OfficeId = 1,


            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "2d5ef183-2290-4248-8b9c-b2b3486fa99b",
                UserId = "4a2e1650-21bd-4e67-832e-2e99c267a2e4",
            });
            builder.Entity<Roles>().HasData(new Roles()
            {
                Id = "e420ab41-8204-4604-a5bd-ca77e88def9c",
                Name = "SuperAdmin",
                Name_Ar = "مالك النظام",
                NormalizedName = "SUPERADMIN"

            }, new Roles()
            {
                Id = "2d5ef183-2290-4248-8b9c-b2b3486fa99b",
                Name = "Admin",
                Name_Ar = "مدير النظام",
                NormalizedName = "ADMIN"
            },
          new Roles()
          {
              Id = "e0134b31-3f25-465a-9eed-c8d07e430668",
              Name = "User",
              Name_Ar = "مستخدم",
              NormalizedName = "USER"
          });
            builder.Entity<AttachedDocument>(entity =>
            {
                entity.HasKey(e => e.DocumentId)
                    .HasName("PK__Attached__1ABEEF6F64994F65");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.AttachedDocuments)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Requests_AttachedDocuments");
            });

            builder.Entity<CheckCondition>(entity =>
            {
                entity.HasOne(d => d.License)
                    .WithMany(p => p.CheckConditions)
                    .HasForeignKey(d => d.LicenseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RestrictedLicenses_CheckConditions");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.CheckConditions)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Offices_CheckConditions");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.CheckConditions)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Requests_CheckConditions");

                entity.HasOne(d => d.Trader)
                    .WithMany(p => p.CheckConditions)
                    .HasForeignKey(d => d.TraderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Traders_CheckConditions");
            });

            builder.Entity<CommercialRegistry>(entity =>
            {
                entity.HasOne(d => d.Trader)
                    .WithMany(p => p.CommercialRegistries)
                    .HasForeignKey(d => d.TraderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Traders_CommercialRegistry");
            });
            builder.Entity<Directorate>(entity =>
            {
                entity.HasOne(d => d.Governorate)
                    .WithMany(p => p.Directorates)
                    .HasForeignKey(d => d.GovernorateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Governorate_Directorates");
            });


            builder.Entity<ImportedDetail>(entity =>
            {
                entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Monitoring)
                    .WithMany(p => p.ImportedDetails)
                    .HasForeignKey(d => d.MonitoringId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("InventoryMonitoring_ImportedDetails");
            });

            builder.Entity<InventoryMonitoring>(entity =>
            {
                entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Movement)
                    .WithMany(p => p.InventoryMonitorings)
                    .HasForeignKey(d => d.MovementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("InventoryMovements_InventoryMonitoring");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.InventoryMonitorings)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Offices_InventoryMonitoring");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.InventoryMonitorings)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sectors_InventoryMonitoring");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.InventoryMonitorings)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Stores_InventoryMonitoring");
            });

            builder.Entity<InventoryMovement>(entity =>
            {
                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.InventoryMovements)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sectors_InventoryMovements");
            });

            builder.Entity<Invoice>(entity =>
            {
                entity.HasOne(d => d.InvoiceType)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.InvoiceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("InvoiceTypes_Invoices");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Offices_Invoices");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Requests_Invoices");

                entity.HasOne(d => d.Trader)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.TraderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Traders_Invoices");
            });

            builder.Entity<InvoiceType>(entity =>
            {
                entity.HasOne(d => d.Office)
                    .WithMany(p => p.InvoiceTypes)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Offices_InvoiceTypes");
            });

            builder.Entity<Item>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ItemGroup)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ItemGroupId)
                    .HasConstraintName("ItemGroups_Items");

                entity.HasOne(d => d.OriginCountry)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.OriginCountryId)
                    .HasConstraintName("OriginCountries_Items");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sectors_Items");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("ItemTypes_Items");
            });

            builder.Entity<ItemGroup>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__ItemGrou__149AF30A9218EF8D");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.ParentGroup)
                    .WithMany(p => p.InverseParentGroup)
                    .HasForeignKey(d => d.ParentGroupId)
                    .HasConstraintName("ItemGroups_ParentGroupID");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.ItemGroups)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sectors_ItemGroups");
            });

            builder.Entity<ItemType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__ItemType__516F039560DB38DE");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.ItemTypes)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sectors_ItemTypes");
            });

            builder.Entity<ItemUnit>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.UnitId })
                    .HasName("PK__ItemUnit__3631DD228AA6F4D0");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemUnits)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Items_ItemUnits");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.ItemUnits)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Units_ItemUnits");
            });

            builder.Entity<Office>(entity =>
            {
                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.Offices)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sectors_Offices");

                entity.HasOne(d => d.Governorate)
                    .WithMany(p => p.Offices)
                    .HasForeignKey(d => d.GovernorateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Governorate_Offices");

                entity.HasOne(d => d.Directorate)
                    .WithMany(p => p.Offices)
                    .HasForeignKey(d => d.DirectorateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Directorate_Offices");

            });

            builder.Entity<OriginCountry>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PK__OriginCo__10D160BF55275967");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.OriginCountries)
                   .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sectors_OriginCountries");
            });

            builder.Entity<Owner>(entity =>
            {
                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Owners)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Stores_Owner");
            });

            builder.Entity<Packaging>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.Packagings)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sectors_Packaging");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Packagings)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Units_Packaging");
            });

            builder.Entity<PackingStore>(entity =>
            {
                entity.HasOne(d => d.Office)
                    .WithMany(p => p.PackingStores)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Offices_PackingStore");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.PackingStores)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Requests_PackingStore");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.PackingStores)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Stores_PackingStore");

                entity.HasOne(d => d.Trader)
                    .WithMany(p => p.PackingStores)
                    .HasForeignKey(d => d.TraderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Traders_PackingStore");
            });

            builder.Entity<PaymentReceipt>(entity =>
            {
                entity.HasKey(e => e.ReceiptId)
                    .HasName("PK__PaymentR__CC08C400DAD92670");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.PaymentReceipts)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Invoices_PaymentReceipts");

                entity.HasOne(d => d.InvoiceType)
                    .WithMany(p => p.PaymentReceipts)
                    .HasForeignKey(d => d.InvoiceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("InvoiceTypes_PaymentReceipts");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.PaymentReceipts)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Offices_PaymentReceipts");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.PaymentReceipts)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Requests_PaymentReceipts");

                entity.HasOne(d => d.Trader)
                    .WithMany(p => p.PaymentReceipts)
                    .HasForeignKey(d => d.TraderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Traders_PaymentReceipts");
            });

            builder.Entity<ProductPricing>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ProductPricings)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Items_ProductPricing");

                entity.HasOne(d => d.Packaging)
                    .WithMany(p => p.ProductPricings)
                    .HasForeignKey(d => d.PackagingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Packaging_ProductPricing");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.ProductPricings)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sectors_ProductPricing");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.ProductPricings)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Units_ProductPricing");
            });

            builder.Entity<Request>(entity =>
            {
                entity.Property(e => e.RequestDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Offices_Requests");

                entity.HasOne(d => d.Trader)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.TraderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Traders_Requests");
            });

            builder.Entity<RestrictedLicense>(entity =>
            {
                entity.HasKey(e => e.LicenseId)
                    .HasName("PK__Restrict__72D600A2256DBE76");

                entity.Property(e => e.IssueDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.RestrictedLicenses)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Offices_RestrictedLicenses");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RestrictedLicenses)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Requests_RestrictedLicenses");

                entity.HasOne(d => d.Trader)
                    .WithMany(p => p.RestrictedLicenses)
                    .HasForeignKey(d => d.TraderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Traders_RestrictedLicenses");
            });

            builder.Entity<StockItem>(entity =>
            {
                entity.Property(e => e.SystemDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.StockItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StockItem_Item");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StockItems)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StockItem_Store");
            });

            builder.Entity<Storage>(entity =>
            {
                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Storages)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Offices_Storage");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Storages)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Requests_Storage");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Storages)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Stores_Storage");

                entity.HasOne(d => d.Trader)
                    .WithMany(p => p.Storages)
                    .HasForeignKey(d => d.TraderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Traders_Storage");
            });

            builder.Entity<StorageCondition>(entity =>
            {
                entity.HasOne(d => d.Item)
                    .WithMany(p => p.StorageConditions)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Items_StorageConditions");
            });

            builder.Entity<Store>(entity =>
            {
                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Offices_Stores");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Requests_Stores");

                entity.HasOne(d => d.Trader)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.TraderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Traders_Stores");
            });

            builder.Entity<TaxId>(entity =>
            {
                entity.HasKey(e => e.TaxId1)
                    .HasName("PK__TaxID__711BE08C1D2F6CA6");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.TaxIds)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Offices_TaxID");

                entity.HasOne(d => d.Trader)
                    .WithMany(p => p.TaxIds)
                    .HasForeignKey(d => d.TraderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Traders_TaxID");
            });

            builder.Entity<Trader>(entity =>
            {
                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Traders)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Offices_Traders");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.Traders)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sectors_Traders");
            });

            builder.Entity<Unit>(entity =>
            {
                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.Units)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sectors_Units");
            });

            
            builder.Entity<Users>(entity =>
            {
                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Offices_Users");
            });

            base.OnModelCreating(builder);
            /////////////////////
            //2 الربط بين الحسابات والعمليات 
            /*builder.Entity<Operations>()
             .HasOne(x => x.Accounts)
             .WithOne(xb => xb.Operations)
             .HasForeignKey<Accounts>(xi => xi.Operations_id);*/

            base.OnModelCreating(builder);
        }

        
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_Ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    SectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Discription = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.SectorId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryMovements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovementName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    SectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryMovements", x => x.Id);
                    table.ForeignKey(
                        name: "Sectors_InventoryMovements",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId");
                });

            migrationBuilder.CreateTable(
                name: "ItemGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ranking = table.Column<int>(type: "int", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    ParentGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ItemGrou__149AF30A9218EF8D", x => x.Id);
                    table.ForeignKey(
                        name: "ItemGroups_ParentGroupID",
                        column: x => x.ParentGroupId,
                        principalTable: "ItemGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Sectors_ItemGroups",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId");
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ItemType__516F039560DB38DE", x => x.TypeId);
                    table.ForeignKey(
                        name: "Sectors_ItemTypes",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId");
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.OfficeId);
                    table.ForeignKey(
                        name: "Sectors_Offices",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId");
                });

            migrationBuilder.CreateTable(
                name: "OriginCountries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OriginCo__10D160BF55275967", x => x.CountryId);
                    table.ForeignKey(
                        name: "Sectors_OriginCountries",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId");
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "Sectors_Units",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId");
                });

            migrationBuilder.CreateTable(
                name: "ImportedDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ContractType = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: false),
                    MonitoringId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportedDetails", x => x.Id);
                    table.ForeignKey(
                        name: "InventoryMonitoring_ImportedDetails",
                        column: x => x.MonitoringId,
                        principalTable: "InventoryMovements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsClient = table.Column<bool>(type: "bit", nullable: true),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "Offices_Users",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "OfficeId");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceTypes",
                columns: table => new
                {
                    InvoiceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTypes", x => x.InvoiceTypeId);
                    table.ForeignKey(
                        name: "Offices_InvoiceTypes",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "OfficeId");
                });

            migrationBuilder.CreateTable(
                name: "Traders",
                columns: table => new
                {
                    TraderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraderName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    NumberId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Nationality = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    IssuanceDateId = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssuingAuthorityId = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    StatusId = table.Column<bool>(type: "bit", nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traders", x => x.TraderId);
                    table.ForeignKey(
                        name: "Offices_Traders",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "OfficeId");
                    table.ForeignKey(
                        name: "Sectors_Traders",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId");
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MinLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: true),
                    SoldQuantity = table.Column<int>(type: "int", nullable: true),
                    ProducedQuantity = table.Column<int>(type: "int", nullable: true),
                    ComingQuantity = table.Column<int>(type: "int", nullable: true),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ItemSize = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, defaultValueSql: "(suser_sname())"),
                    OriginCountryId = table.Column<int>(type: "int", nullable: true),
                    ItemGroupId = table.Column<int>(type: "int", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    StorageConditionId = table.Column<int>(type: "int", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "ItemGroups_Items",
                        column: x => x.ItemGroupId,
                        principalTable: "ItemGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ItemTypes_Items",
                        column: x => x.TypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "TypeId");
                    table.ForeignKey(
                        name: "OriginCountries_Items",
                        column: x => x.OriginCountryId,
                        principalTable: "OriginCountries",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "Sectors_Items",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId");
                });

            migrationBuilder.CreateTable(
                name: "Packaging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Size = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packaging", x => x.Id);
                    table.ForeignKey(
                        name: "Sectors_Packaging",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId");
                    table.ForeignKey(
                        name: "Units_Packaging",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommercialRegistry",
                columns: table => new
                {
                    CommercialRegistryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistryNumber = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistryType = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    RegistryCategory = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    OwnerName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    RegistryStatus = table.Column<bool>(type: "bit", nullable: false),
                    TraderId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialRegistry", x => x.CommercialRegistryId);
                    table.ForeignKey(
                        name: "Traders_CommercialRegistry",
                        column: x => x.TraderId,
                        principalTable: "Traders",
                        principalColumn: "TraderId");
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    RequestStatus = table.Column<int>(type: "int", nullable: false),
                    StorMode = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    StorType = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    TraderId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    FeeWaived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                    table.ForeignKey(
                        name: "Offices_Requests",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "OfficeId");
                    table.ForeignKey(
                        name: "Traders_Requests",
                        column: x => x.TraderId,
                        principalTable: "Traders",
                        principalColumn: "TraderId");
                });

            migrationBuilder.CreateTable(
                name: "TaxID",
                columns: table => new
                {
                    TaxId1 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxIdNumber = table.Column<int>(type: "int", nullable: false),
                    Issuer = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    DateLastRenewal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TraderId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TaxID__711BE08C1D2F6CA6", x => x.TaxId1);
                    table.ForeignKey(
                        name: "Offices_TaxID",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "OfficeId");
                    table.ForeignKey(
                        name: "Traders_TaxID",
                        column: x => x.TraderId,
                        principalTable: "Traders",
                        principalColumn: "TraderId");
                });

            migrationBuilder.CreateTable(
                name: "ItemUnits",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ItemUnit__3631DD228AA6F4D0", x => new { x.ItemId, x.UnitId });
                    table.ForeignKey(
                        name: "Items_ItemUnits",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "Units_ItemUnits",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StorageConditions",
                columns: table => new
                {
                    StorageConditionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeciesStorage = table.Column<bool>(type: "bit", nullable: false),
                    IlluminationLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenusAndLightSlots = table.Column<bool>(type: "bit", nullable: false),
                    HumidityLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HeatLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StorageType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageConditions", x => x.StorageConditionId);
                    table.ForeignKey(
                        name: "Items_StorageConditions",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId");
                });

            migrationBuilder.CreateTable(
                name: "ProductPricing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    PackagingId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPricing", x => x.Id);
                    table.ForeignKey(
                        name: "Items_ProductPricing",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "Packaging_ProductPricing",
                        column: x => x.PackagingId,
                        principalTable: "Packaging",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Sectors_ProductPricing",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId");
                    table.ForeignKey(
                        name: "Units_ProductPricing",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AttachedDocuments",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Attached__1ABEEF6F64994F65", x => x.DocumentId);
                    table.ForeignKey(
                        name: "Requests_AttachedDocuments",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceTypeId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    TraderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "InvoiceTypes_Invoices",
                        column: x => x.InvoiceTypeId,
                        principalTable: "InvoiceTypes",
                        principalColumn: "InvoiceTypeId");
                    table.ForeignKey(
                        name: "Offices_Invoices",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "OfficeId");
                    table.ForeignKey(
                        name: "Requests_Invoices",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId");
                    table.ForeignKey(
                        name: "Traders_Invoices",
                        column: x => x.TraderId,
                        principalTable: "Traders",
                        principalColumn: "TraderId");
                });

            migrationBuilder.CreateTable(
                name: "RestrictedLicenses",
                columns: table => new
                {
                    LicenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseNumber = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    TraderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Restrict__72D600A2256DBE76", x => x.LicenseId);
                    table.ForeignKey(
                        name: "Offices_RestrictedLicenses",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "OfficeId");
                    table.ForeignKey(
                        name: "Requests_RestrictedLicenses",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId");
                    table.ForeignKey(
                        name: "Traders_RestrictedLicenses",
                        column: x => x.TraderId,
                        principalTable: "Traders",
                        principalColumn: "TraderId");
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Governorate = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    District = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Street = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    NextTo = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Status = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    StoreType = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    TraderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreId);
                    table.ForeignKey(
                        name: "Offices_Stores",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "OfficeId");
                    table.ForeignKey(
                        name: "Requests_Stores",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId");
                    table.ForeignKey(
                        name: "Traders_Stores",
                        column: x => x.TraderId,
                        principalTable: "Traders",
                        principalColumn: "TraderId");
                });

            migrationBuilder.CreateTable(
                name: "PaymentReceipts",
                columns: table => new
                {
                    ReceiptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    PaymentReference = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    InvoiceTypeId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    TraderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PaymentR__CC08C400DAD92670", x => x.ReceiptId);
                    table.ForeignKey(
                        name: "Invoices_PaymentReceipts",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId");
                    table.ForeignKey(
                        name: "InvoiceTypes_PaymentReceipts",
                        column: x => x.InvoiceTypeId,
                        principalTable: "InvoiceTypes",
                        principalColumn: "InvoiceTypeId");
                    table.ForeignKey(
                        name: "Offices_PaymentReceipts",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "OfficeId");
                    table.ForeignKey(
                        name: "Requests_PaymentReceipts",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId");
                    table.ForeignKey(
                        name: "Traders_PaymentReceipts",
                        column: x => x.TraderId,
                        principalTable: "Traders",
                        principalColumn: "TraderId");
                });

            migrationBuilder.CreateTable(
                name: "CheckConditions",
                columns: table => new
                {
                    CheckConditionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dpsar = table.Column<bool>(type: "bit", nullable: false),
                    Slpr = table.Column<bool>(type: "bit", nullable: false),
                    Aspgp = table.Column<bool>(type: "bit", nullable: false),
                    Vca = table.Column<bool>(type: "bit", nullable: false),
                    Cdp = table.Column<bool>(type: "bit", nullable: false),
                    Ifr = table.Column<bool>(type: "bit", nullable: false),
                    Ivee = table.Column<bool>(type: "bit", nullable: false),
                    Hcsw = table.Column<bool>(type: "bit", nullable: false),
                    Refe = table.Column<int>(type: "int", nullable: false),
                    Tr4 = table.Column<bool>(type: "bit", nullable: false),
                    Tmd = table.Column<bool>(type: "bit", nullable: false),
                    Lrc = table.Column<bool>(type: "bit", nullable: false),
                    Ars = table.Column<bool>(type: "bit", nullable: false),
                    Ssi = table.Column<bool>(type: "bit", nullable: false),
                    Tvp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LicenseId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    TraderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckConditions", x => x.CheckConditionId);
                    table.ForeignKey(
                        name: "Offices_CheckConditions",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "OfficeId");
                    table.ForeignKey(
                        name: "Requests_CheckConditions",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId");
                    table.ForeignKey(
                        name: "RestrictedLicenses_CheckConditions",
                        column: x => x.LicenseId,
                        principalTable: "RestrictedLicenses",
                        principalColumn: "LicenseId");
                    table.ForeignKey(
                        name: "Traders_CheckConditions",
                        column: x => x.TraderId,
                        principalTable: "Traders",
                        principalColumn: "TraderId");
                });

            migrationBuilder.CreateTable(
                name: "InventoryMonitoring",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ItemName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TypePackaging = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UnitStrength = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentBalance = table.Column<int>(type: "int", nullable: false),
                    MovementId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryMonitoring", x => x.Id);
                    table.ForeignKey(
                        name: "InventoryMovements_InventoryMonitoring",
                        column: x => x.MovementId,
                        principalTable: "InventoryMovements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Offices_InventoryMonitoring",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "OfficeId");
                    table.ForeignKey(
                        name: "Sectors_InventoryMonitoring",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId");
                    table.ForeignKey(
                        name: "Stores_InventoryMonitoring",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId");
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.OwnerId);
                    table.ForeignKey(
                        name: "Stores_Owner",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId");
                });

            migrationBuilder.CreateTable(
                name: "PackingStore",
                columns: table => new
                {
                    PackingStoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionLineCount = table.Column<int>(type: "int", nullable: false),
                    ProductionLineCapacity = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    TraderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackingStore", x => x.PackingStoreId);
                    table.ForeignKey(
                        name: "Offices_PackingStore",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "OfficeId");
                    table.ForeignKey(
                        name: "Requests_PackingStore",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId");
                    table.ForeignKey(
                        name: "Stores_PackingStore",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId");
                    table.ForeignKey(
                        name: "Traders_PackingStore",
                        column: x => x.TraderId,
                        principalTable: "Traders",
                        principalColumn: "TraderId");
                });

            migrationBuilder.CreateTable(
                name: "StockItem",
                columns: table => new
                {
                    StockItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SystemDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    TypeStockItem = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItem", x => x.StockItemId);
                    table.ForeignKey(
                        name: "FK_StockItem_Item",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "FK_StockItem_Store",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId");
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    StorageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingType = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    NumberOpen = table.Column<int>(type: "int", nullable: false),
                    StorageVolume = table.Column<int>(type: "int", nullable: false),
                    StorageCapacity = table.Column<int>(type: "int", nullable: false),
                    SizeItem = table.Column<double>(type: "float", nullable: false),
                    ItemStorageConditions = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    StoreStorageConditions = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    TraderId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.StorageId);
                    table.ForeignKey(
                        name: "Offices_Storage",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "OfficeId");
                    table.ForeignKey(
                        name: "Requests_Storage",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId");
                    table.ForeignKey(
                        name: "Stores_Storage",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId");
                    table.ForeignKey(
                        name: "Traders_Storage",
                        column: x => x.TraderId,
                        principalTable: "Traders",
                        principalColumn: "TraderId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "Name_Ar", "NormalizedName" },
                values: new object[,]
                {
                    { "2d5ef183-2290-4248-8b9c-b2b3486fa99b", "01746b90-fc85-4790-99bb-ea6695932956", "Roles", "Admin", "مدير النظام", "ADMIN" },
                    { "e0134b31-3f25-465a-9eed-c8d07e430668", "a16b95d1-6ca9-44fb-b8e9-5453794352cd", "Roles", "User", "مستخدم", "USER" },
                    { "e420ab41-8204-4604-a5bd-ca77e88def9c", "fabc096f-c3d9-41cb-9107-30ca5ee23501", "Roles", "SuperAdmin", "مالك النظام", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Sectors",
                columns: new[] { "SectorId", "Discription", "SectorName", "Status" },
                values: new object[] { 1, "SuperAdmin", "صنعاء", false });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "OfficeId", "Address", "OfficeName", "SectorId" },
                values: new object[] { 1, "SuperAdmin", "صنعاء", 1 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "IsClient", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "OfficeId", "Pass", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "TypeUser", "UserName" },
                values: new object[] { "4a2e1650-21bd-4e67-832e-2e99c267a2e4", 0, "1e64c192-0c7a-4970-8831-fe8a881ad45e", "Users", "Admin@gmail.com", false, true, false, null, "رئيس مجلس الادارة", "ADMIN@GMAIL.COM", "SUPERADMIN", 1, "Admin123", "AQAAAAEAACcQAAAAEKmwJ00dhgL1NIt/XKmXaPjBWhlWDdO5syi9+vNcujzzI8u7z3+WQjlkYHQM4zfAVw==", "778877887", false, "7d5c2a7f-7504-4ff9-a41b-9efc32ebbad2", false, null, "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2d5ef183-2290-4248-8b9c-b2b3486fa99b", "4a2e1650-21bd-4e67-832e-2e99c267a2e4" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OfficeId",
                table: "AspNetUsers",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AttachedDocuments_RequestId",
                table: "AttachedDocuments",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckConditions_LicenseId",
                table: "CheckConditions",
                column: "LicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckConditions_OfficeId",
                table: "CheckConditions",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckConditions_RequestId",
                table: "CheckConditions",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckConditions_TraderId",
                table: "CheckConditions",
                column: "TraderId");

            migrationBuilder.CreateIndex(
                name: "IX_CommercialRegistry_TraderId",
                table: "CommercialRegistry",
                column: "TraderId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportedDetails_MonitoringId",
                table: "ImportedDetails",
                column: "MonitoringId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMonitoring_MovementId",
                table: "InventoryMonitoring",
                column: "MovementId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMonitoring_OfficeId",
                table: "InventoryMonitoring",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMonitoring_SectorId",
                table: "InventoryMonitoring",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMonitoring_StoreId",
                table: "InventoryMonitoring",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_SectorId",
                table: "InventoryMovements",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceTypeId",
                table: "Invoices",
                column: "InvoiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OfficeId",
                table: "Invoices",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_RequestId",
                table: "Invoices",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_TraderId",
                table: "Invoices",
                column: "TraderId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTypes_OfficeId",
                table: "InvoiceTypes",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroups_ParentGroupId",
                table: "ItemGroups",
                column: "ParentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroups_SectorId",
                table: "ItemGroups",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemGroupId",
                table: "Items",
                column: "ItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_OriginCountryId",
                table: "Items",
                column: "OriginCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SectorId",
                table: "Items",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_TypeId",
                table: "Items",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypes_SectorId",
                table: "ItemTypes",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemUnits_UnitId",
                table: "ItemUnits",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_SectorId",
                table: "Offices",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_OriginCountries_SectorId",
                table: "OriginCountries",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Owner_StoreId",
                table: "Owner",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Packaging_SectorId",
                table: "Packaging",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Packaging_UnitId",
                table: "Packaging",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PackingStore_OfficeId",
                table: "PackingStore",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_PackingStore_RequestId",
                table: "PackingStore",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PackingStore_StoreId",
                table: "PackingStore",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_PackingStore_TraderId",
                table: "PackingStore",
                column: "TraderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReceipts_InvoiceId",
                table: "PaymentReceipts",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReceipts_InvoiceTypeId",
                table: "PaymentReceipts",
                column: "InvoiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReceipts_OfficeId",
                table: "PaymentReceipts",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReceipts_RequestId",
                table: "PaymentReceipts",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReceipts_TraderId",
                table: "PaymentReceipts",
                column: "TraderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPricing_ItemID",
                table: "ProductPricing",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPricing_PackagingId",
                table: "ProductPricing",
                column: "PackagingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPricing_SectorId",
                table: "ProductPricing",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPricing_UnitId",
                table: "ProductPricing",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_OfficeId",
                table: "Requests",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_TraderId",
                table: "Requests",
                column: "TraderId");

            migrationBuilder.CreateIndex(
                name: "IX_RestrictedLicenses_OfficeId",
                table: "RestrictedLicenses",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_RestrictedLicenses_RequestId",
                table: "RestrictedLicenses",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RestrictedLicenses_TraderId",
                table: "RestrictedLicenses",
                column: "TraderId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItem_ItemId",
                table: "StockItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItem_StoreId",
                table: "StockItem",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_OfficeId",
                table: "Storage",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_RequestId",
                table: "Storage",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_StoreId",
                table: "Storage",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_TraderId",
                table: "Storage",
                column: "TraderId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageConditions_ItemId",
                table: "StorageConditions",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_OfficeId",
                table: "Stores",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_RequestId",
                table: "Stores",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_TraderId",
                table: "Stores",
                column: "TraderId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxID_OfficeId",
                table: "TaxID",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxID_TraderId",
                table: "TaxID",
                column: "TraderId");

            migrationBuilder.CreateIndex(
                name: "UQ__TaxID__14068BFD276D7E67",
                table: "TaxID",
                column: "TaxIdNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Traders_OfficeId",
                table: "Traders",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Traders_SectorId",
                table: "Traders",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "UQ__Traders__FF1D98271D41B72A",
                table: "Traders",
                column: "NumberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_SectorId",
                table: "Units",
                column: "SectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AttachedDocuments");

            migrationBuilder.DropTable(
                name: "CheckConditions");

            migrationBuilder.DropTable(
                name: "CommercialRegistry");

            migrationBuilder.DropTable(
                name: "ImportedDetails");

            migrationBuilder.DropTable(
                name: "InventoryMonitoring");

            migrationBuilder.DropTable(
                name: "ItemUnits");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "PackingStore");

            migrationBuilder.DropTable(
                name: "PaymentReceipts");

            migrationBuilder.DropTable(
                name: "ProductPricing");

            migrationBuilder.DropTable(
                name: "StockItem");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "StorageConditions");

            migrationBuilder.DropTable(
                name: "TaxID");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "RestrictedLicenses");

            migrationBuilder.DropTable(
                name: "InventoryMovements");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Packaging");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "InvoiceTypes");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "ItemGroups");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "OriginCountries");

            migrationBuilder.DropTable(
                name: "Traders");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Sectors");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Migrations
{
    public partial class AddGovernoratesAndDirectorateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DirectorateName",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GovernorateName",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DirectorateId",
                table: "Offices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GovernorateId",
                table: "Offices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DirectorateName",
                table: "InventoryMonitoring",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GovernorateName",
                table: "InventoryMonitoring",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DirectorateName",
                table: "CheckConditions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GovernorateName",
                table: "CheckConditions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DirectorateName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GovernorateName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Governorates",
                columns: table => new
                {
                    GovernorateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GovernorateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorates", x => x.GovernorateId);
                });

            migrationBuilder.CreateTable(
                name: "Directorates",
                columns: table => new
                {
                    DirectorateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectorateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovernorateId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directorates", x => x.DirectorateId);
                    table.ForeignKey(
                        name: "Governorate_Directorates",
                        column: x => x.GovernorateId,
                        principalTable: "Governorates",
                        principalColumn: "GovernorateId");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5ef183-2290-4248-8b9c-b2b3486fa99b",
                column: "ConcurrencyStamp",
                value: "817f2428-b6bc-4840-9154-5d1fa80335ab");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0134b31-3f25-465a-9eed-c8d07e430668",
                column: "ConcurrencyStamp",
                value: "13a680df-816d-4306-bff4-78f7599763a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e420ab41-8204-4604-a5bd-ca77e88def9c",
                column: "ConcurrencyStamp",
                value: "f26b6c27-1938-43b4-a519-c264e04848d0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2e1650-21bd-4e67-832e-2e99c267a2e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d44dbce7-b143-473b-baa6-f4ec151258d6", "AQAAAAEAACcQAAAAEPiC8U1Hacmpt/nWi6aKYUz4LLXksJZ+ZfHgZiStG5UN+30dQkw5Zigk+PyhODxDWw==", "59aabb9c-a2ac-443b-8072-d9e5cfa17819" });

            migrationBuilder.InsertData(
                table: "Governorates",
                columns: new[] { "GovernorateId", "CreatedDate", "GovernorateName" },
                values: new object[] { 1, new DateTime(2023, 6, 26, 4, 25, 5, 682, DateTimeKind.Local).AddTicks(788), "صنعاء" });

            migrationBuilder.InsertData(
                table: "Directorates",
                columns: new[] { "DirectorateId", "CreatedDate", "DirectorateName", "GovernorateId" },
                values: new object[] { 1, new DateTime(2023, 6, 26, 4, 25, 5, 682, DateTimeKind.Local).AddTicks(835), "الامانة", 1 });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "OfficeId",
                keyValue: 1,
                columns: new[] { "Address", "DirectorateId", "GovernorateId", "OfficeName" },
                values: new object[] { "الحصبة", 1, 1, "الغرفة التجارية" });

            migrationBuilder.CreateIndex(
                name: "IX_Offices_DirectorateId",
                table: "Offices",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_GovernorateId",
                table: "Offices",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Directorates_GovernorateId",
                table: "Directorates",
                column: "GovernorateId");

            migrationBuilder.AddForeignKey(
                name: "Directorate_Offices",
                table: "Offices",
                column: "DirectorateId",
                principalTable: "Directorates",
                principalColumn: "DirectorateId");

            migrationBuilder.AddForeignKey(
                name: "Governorate_Offices",
                table: "Offices",
                column: "GovernorateId",
                principalTable: "Governorates",
                principalColumn: "GovernorateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Directorate_Offices",
                table: "Offices");

            migrationBuilder.DropForeignKey(
                name: "Governorate_Offices",
                table: "Offices");

            migrationBuilder.DropTable(
                name: "Directorates");

            migrationBuilder.DropTable(
                name: "Governorates");

            migrationBuilder.DropIndex(
                name: "IX_Offices_DirectorateId",
                table: "Offices");

            migrationBuilder.DropIndex(
                name: "IX_Offices_GovernorateId",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "DirectorateName",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "GovernorateName",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DirectorateId",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "GovernorateId",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "DirectorateName",
                table: "InventoryMonitoring");

            migrationBuilder.DropColumn(
                name: "GovernorateName",
                table: "InventoryMonitoring");

            migrationBuilder.DropColumn(
                name: "DirectorateName",
                table: "CheckConditions");

            migrationBuilder.DropColumn(
                name: "GovernorateName",
                table: "CheckConditions");

            migrationBuilder.DropColumn(
                name: "DirectorateName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GovernorateName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5ef183-2290-4248-8b9c-b2b3486fa99b",
                column: "ConcurrencyStamp",
                value: "01746b90-fc85-4790-99bb-ea6695932956");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0134b31-3f25-465a-9eed-c8d07e430668",
                column: "ConcurrencyStamp",
                value: "a16b95d1-6ca9-44fb-b8e9-5453794352cd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e420ab41-8204-4604-a5bd-ca77e88def9c",
                column: "ConcurrencyStamp",
                value: "fabc096f-c3d9-41cb-9107-30ca5ee23501");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2e1650-21bd-4e67-832e-2e99c267a2e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e64c192-0c7a-4970-8831-fe8a881ad45e", "AQAAAAEAACcQAAAAEKmwJ00dhgL1NIt/XKmXaPjBWhlWDdO5syi9+vNcujzzI8u7z3+WQjlkYHQM4zfAVw==", "7d5c2a7f-7504-4ff9-a41b-9efc32ebbad2" });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "OfficeId",
                keyValue: 1,
                columns: new[] { "Address", "OfficeName" },
                values: new object[] { "SuperAdmin", "صنعاء" });
        }
    }
}

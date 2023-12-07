using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class Update_Schema_Stock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StockReleaseTypeId",
                schema: "stock",
                table: "StockRelease",
                newName: "StockReleaseType");

            migrationBuilder.RenameColumn(
                name: "PreviousQuantity",
                schema: "stock",
                table: "StockRelease",
                newName: "NextBalance");

            migrationBuilder.AddColumn<decimal>(
                name: "PreviousBalance",
                schema: "stock",
                table: "StockRelease",
                type: "decimal(19,9)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StockReleaseId",
                schema: "stock",
                table: "StockRelease",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "UserProfile",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("07734f1e-54f9-4140-bb1f-cc3ca6064900"));

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("6ff2c236-c89d-4bf6-a8f9-fb66101704b3"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviousBalance",
                schema: "stock",
                table: "StockRelease");

            migrationBuilder.DropColumn(
                name: "StockReleaseId",
                schema: "stock",
                table: "StockRelease");

            migrationBuilder.RenameColumn(
                name: "StockReleaseType",
                schema: "stock",
                table: "StockRelease",
                newName: "StockReleaseTypeId");

            migrationBuilder.RenameColumn(
                name: "NextBalance",
                schema: "stock",
                table: "StockRelease",
                newName: "PreviousQuantity");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "UserProfile",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("dcd4a93f-0ec1-452e-8a22-09d37f6e464d"));

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("5a0f1306-94e8-4a98-9916-2ed716aa13ae"));
        }
    }
}

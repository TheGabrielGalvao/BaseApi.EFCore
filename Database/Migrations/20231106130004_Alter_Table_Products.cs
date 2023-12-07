using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class Alter_Table_Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AffectsStock",
                schema: "product",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "MinimalStock",
                schema: "product",
                table: "Products",
                type: "decimal(19,9)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StockLocationId",
                schema: "product",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "UserProfile",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("d27f1c71-3470-417c-8f5f-b43e16c85d14"));

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("e706f218-97d8-4a20-b4f3-9e3de4c9e576"));

            migrationBuilder.CreateIndex(
                name: "IX_Products_StockLocationId",
                schema: "product",
                table: "Products",
                column: "StockLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_StockLocation_StockLocationId",
                schema: "product",
                table: "Products",
                column: "StockLocationId",
                principalSchema: "stock",
                principalTable: "StockLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_StockLocation_StockLocationId",
                schema: "product",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_StockLocationId",
                schema: "product",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AffectsStock",
                schema: "product",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MinimalStock",
                schema: "product",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StockLocationId",
                schema: "product",
                table: "Products");

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
    }
}

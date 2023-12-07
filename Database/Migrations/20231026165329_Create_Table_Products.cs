using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class Create_Table_Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    ProductCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategory_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalSchema: "product",
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "UserProfile",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("a4189548-2a3b-4f63-9746-bf163ebe737a"));

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("f23f7976-2e49-4100-8b36-5215566fcdd2"));

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                schema: "product",
                table: "Products",
                column: "ProductCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "product");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "UserProfile",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("848cfde9-b61c-4c84-b9f4-71aaadb0c0f0"));

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("98a521f4-34f4-4abc-8f61-045a7701df01"));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class Create_Schema_Stock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "stock");

            migrationBuilder.CreateTable(
                name: "StockLocation",
                schema: "stock",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(45)", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryAdjustment",
                schema: "stock",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(25)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,9)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Flow = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    StockLocationId = table.Column<long>(type: "bigint", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryAdjustment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryAdjustment_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryAdjustment_StockLocation_StockLocationId",
                        column: x => x.StockLocationId,
                        principalSchema: "stock",
                        principalTable: "StockLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockBalance",
                schema: "stock",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<decimal>(type: "decimal(19,9)", nullable: true),
                    StockLocationId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockBalance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockBalance_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockBalance_StockLocation_StockLocationId",
                        column: x => x.StockLocationId,
                        principalSchema: "stock",
                        principalTable: "StockLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockRelease",
                schema: "stock",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(45)", nullable: false),
                    PreviousQuantity = table.Column<decimal>(type: "decimal(19,9)", nullable: false),
                    QuantityReleased = table.Column<decimal>(type: "decimal(19,9)", nullable: false),
                    Flow = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StockReleaseTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    StockLocationId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockRelease", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockRelease_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockRelease_StockLocation_StockLocationId",
                        column: x => x.StockLocationId,
                        principalSchema: "stock",
                        principalTable: "StockLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockRelease_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "stock",
                table: "StockLocation",
                columns: new[] { "Id", "Description", "Name", "Status", "Uuid" },
                values: new object[] { 1L, "Local de Estoque Padrão", "Padrão", 1, new Guid("595980be-1635-4ca1-987d-eddbd1fb15d8") });

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

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAdjustment_ProductId",
                schema: "stock",
                table: "InventoryAdjustment",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAdjustment_StockLocationId",
                schema: "stock",
                table: "InventoryAdjustment",
                column: "StockLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_StockBalance_ProductId",
                schema: "stock",
                table: "StockBalance",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockBalance_StockLocationId",
                schema: "stock",
                table: "StockBalance",
                column: "StockLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_StockRelease_ProductId",
                schema: "stock",
                table: "StockRelease",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockRelease_StockLocationId",
                schema: "stock",
                table: "StockRelease",
                column: "StockLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_StockRelease_UserId",
                schema: "stock",
                table: "StockRelease",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryAdjustment",
                schema: "stock");

            migrationBuilder.DropTable(
                name: "StockBalance",
                schema: "stock");

            migrationBuilder.DropTable(
                name: "StockRelease",
                schema: "stock");

            migrationBuilder.DropTable(
                name: "StockLocation",
                schema: "stock");

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
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class Recreate_Schema_Financial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialRelease_FinancialReleaseType_FinancialReleaseTypeId",
                schema: "financial",
                table: "FinancialRelease");

            migrationBuilder.RenameColumn(
                name: "Value",
                schema: "financial",
                table: "FinancialRelease",
                newName: "ReleasedValue");

            migrationBuilder.RenameColumn(
                name: "Operation",
                schema: "financial",
                table: "FinancialRelease",
                newName: "Flow");

            migrationBuilder.RenameColumn(
                name: "FinancialReleaseTypeId",
                schema: "financial",
                table: "FinancialRelease",
                newName: "WalletId");

            migrationBuilder.RenameIndex(
                name: "IX_FinancialRelease_FinancialReleaseTypeId",
                schema: "financial",
                table: "FinancialRelease",
                newName: "IX_FinancialRelease_WalletId");

            migrationBuilder.AddColumn<int>(
                name: "FinancialReleaseType",
                schema: "financial",
                table: "FinancialRelease",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "FinancialReleaseTypeEntityId",
                schema: "financial",
                table: "FinancialRelease",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NextBalance",
                schema: "financial",
                table: "FinancialRelease",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PreviousBalance",
                schema: "financial",
                table: "FinancialRelease",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "TransactionCode",
                schema: "financial",
                table: "FinancialRelease",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Wallet",
                schema: "financial",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialBalance",
                schema: "financial",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WalletId = table.Column<long>(type: "bigint", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialBalance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialBalance_Wallet_WalletId",
                        column: x => x.WalletId,
                        principalSchema: "financial",
                        principalTable: "Wallet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManualTransaction",
                schema: "financial",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Flow = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ContactId = table.Column<long>(type: "bigint", nullable: true),
                    WalletId = table.Column<long>(type: "bigint", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManualTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManualTransaction_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ManualTransaction_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManualTransaction_Wallet_WalletId",
                        column: x => x.WalletId,
                        principalSchema: "financial",
                        principalTable: "Wallet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "UserProfile",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("7d26713a-314f-440a-8d49-4f1309a6dd95"));

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("a3053bdc-74b5-4382-a57d-98e9b8a4948c"));

            migrationBuilder.InsertData(
                schema: "financial",
                table: "Wallet",
                columns: new[] { "Id", "Name", "Status", "Type", "Uuid" },
                values: new object[] { 1L, "Conta Padrão", 1, 0, new Guid("c6eccdb4-29ab-4f65-ba92-7b6580619436") });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialRelease_FinancialReleaseTypeEntityId",
                schema: "financial",
                table: "FinancialRelease",
                column: "FinancialReleaseTypeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialBalance_WalletId",
                schema: "financial",
                table: "FinancialBalance",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_ManualTransaction_ContactId",
                schema: "financial",
                table: "ManualTransaction",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ManualTransaction_UserId",
                schema: "financial",
                table: "ManualTransaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ManualTransaction_WalletId",
                schema: "financial",
                table: "ManualTransaction",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialRelease_FinancialReleaseType_FinancialReleaseTypeEntityId",
                schema: "financial",
                table: "FinancialRelease",
                column: "FinancialReleaseTypeEntityId",
                principalSchema: "financial",
                principalTable: "FinancialReleaseType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialRelease_Wallet_WalletId",
                schema: "financial",
                table: "FinancialRelease",
                column: "WalletId",
                principalSchema: "financial",
                principalTable: "Wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialRelease_FinancialReleaseType_FinancialReleaseTypeEntityId",
                schema: "financial",
                table: "FinancialRelease");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialRelease_Wallet_WalletId",
                schema: "financial",
                table: "FinancialRelease");

            migrationBuilder.DropTable(
                name: "FinancialBalance",
                schema: "financial");

            migrationBuilder.DropTable(
                name: "ManualTransaction",
                schema: "financial");

            migrationBuilder.DropTable(
                name: "Wallet",
                schema: "financial");

            migrationBuilder.DropIndex(
                name: "IX_FinancialRelease_FinancialReleaseTypeEntityId",
                schema: "financial",
                table: "FinancialRelease");

            migrationBuilder.DropColumn(
                name: "FinancialReleaseType",
                schema: "financial",
                table: "FinancialRelease");

            migrationBuilder.DropColumn(
                name: "FinancialReleaseTypeEntityId",
                schema: "financial",
                table: "FinancialRelease");

            migrationBuilder.DropColumn(
                name: "NextBalance",
                schema: "financial",
                table: "FinancialRelease");

            migrationBuilder.DropColumn(
                name: "PreviousBalance",
                schema: "financial",
                table: "FinancialRelease");

            migrationBuilder.DropColumn(
                name: "TransactionCode",
                schema: "financial",
                table: "FinancialRelease");

            migrationBuilder.RenameColumn(
                name: "WalletId",
                schema: "financial",
                table: "FinancialRelease",
                newName: "FinancialReleaseTypeId");

            migrationBuilder.RenameColumn(
                name: "ReleasedValue",
                schema: "financial",
                table: "FinancialRelease",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Flow",
                schema: "financial",
                table: "FinancialRelease",
                newName: "Operation");

            migrationBuilder.RenameIndex(
                name: "IX_FinancialRelease_WalletId",
                schema: "financial",
                table: "FinancialRelease",
                newName: "IX_FinancialRelease_FinancialReleaseTypeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialRelease_FinancialReleaseType_FinancialReleaseTypeId",
                schema: "financial",
                table: "FinancialRelease",
                column: "FinancialReleaseTypeId",
                principalSchema: "financial",
                principalTable: "FinancialReleaseType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

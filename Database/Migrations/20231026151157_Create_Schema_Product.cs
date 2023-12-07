using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class Create_Schema_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "product");

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "product");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "UserProfile",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("9f1ab48a-9783-435e-b600-01f67393782d"));

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("fadf7195-6ae3-46ba-9e96-afbc203e9a46"));
        }
    }
}

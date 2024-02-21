using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleWMS.Migrations
{
    /// <inheritdoc />
    public partial class fk3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChangeInQuantity",
                table: "StockInOut",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "StockInOut",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A high-performance laptop", "Laptop" },
                    { 2, "An innovative smartphone", "Smartphone" }
                });

            migrationBuilder.InsertData(
                table: "InventoryItem",
                columns: new[] { "Id", "LocationName", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, "Warehouse A", 1, 130 },
                    { 2, "Warehouse B", 2, 200 }
                });

            migrationBuilder.InsertData(
                table: "StockInOut",
                columns: new[] { "Id", "AfterQuantity", "ChangeInQuantity", "Date", "InventoryItemId", "PreviousQuantity", "TransactionType" },
                values: new object[,]
                {
                    { 1, 130, 30, new DateTime(2024, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, 100, 0 },
                    { 2, 100, -100, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 200, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StockInOut",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StockInOut",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InventoryItem",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InventoryItem",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ChangeInQuantity",
                table: "StockInOut");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "StockInOut");
        }
    }
}

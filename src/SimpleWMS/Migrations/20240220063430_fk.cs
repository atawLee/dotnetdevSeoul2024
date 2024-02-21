using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleWMS.Migrations
{
    /// <inheritdoc />
    public partial class fk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "StockInOut",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InventoryItemId",
                table: "StockInOut",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "InventoryItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StockInOut_InventoryId",
                table: "StockInOut",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockInOut_InventoryItem_InventoryId",
                table: "StockInOut",
                column: "InventoryId",
                principalTable: "InventoryItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockInOut_InventoryItem_InventoryId",
                table: "StockInOut");

            migrationBuilder.DropIndex(
                name: "IX_StockInOut_InventoryId",
                table: "StockInOut");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "StockInOut");

            migrationBuilder.DropColumn(
                name: "InventoryItemId",
                table: "StockInOut");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "InventoryItem");
        }
    }
}

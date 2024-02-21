using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleWMS.Migrations
{
    /// <inheritdoc />
    public partial class fk2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "InventoryItemId",
                table: "StockInOut",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_StockInOut_InventoryItemId",
                table: "StockInOut",
                column: "InventoryItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockInOut_InventoryItem_InventoryItemId",
                table: "StockInOut",
                column: "InventoryItemId",
                principalTable: "InventoryItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockInOut_InventoryItem_InventoryItemId",
                table: "StockInOut");

            migrationBuilder.DropIndex(
                name: "IX_StockInOut_InventoryItemId",
                table: "StockInOut");

            migrationBuilder.AlterColumn<string>(
                name: "InventoryItemId",
                table: "StockInOut",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "StockInOut",
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
    }
}

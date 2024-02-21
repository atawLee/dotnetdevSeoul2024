using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleWMS.Migrations
{
    /// <inheritdoc />
    public partial class locationColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "InventoryItem",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "InventoryItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: null);

            migrationBuilder.UpdateData(
                table: "InventoryItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "Location",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "InventoryItem");
        }
    }
}

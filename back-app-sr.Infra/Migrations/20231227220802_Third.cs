using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_app_sr.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "QuickSaleItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QuickSaleItems_ItemId",
                table: "QuickSaleItems",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuickSaleItems_Items_ItemId",
                table: "QuickSaleItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuickSaleItems_Items_ItemId",
                table: "QuickSaleItems");

            migrationBuilder.DropIndex(
                name: "IX_QuickSaleItems_ItemId",
                table: "QuickSaleItems");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "QuickSaleItems");
        }
    }
}

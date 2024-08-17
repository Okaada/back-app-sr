using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_app_sr.Infra.Migrations
{
    /// <inheritdoc />
    public partial class RemovingUnusedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrdersTabItems_Additionals_AdditionalId",
                table: "ItemOrdersTabItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrdersTabItems_Items_ItemId",
                table: "ItemOrdersTabItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Tabs_TabModelId",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "OrdersTab");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tabs",
                table: "Tabs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersTabItems",
                table: "OrdersTabItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemOrdersTabItems",
                table: "ItemOrdersTabItems");

            migrationBuilder.RenameTable(
                name: "Tabs",
                newName: "Tab");

            migrationBuilder.RenameTable(
                name: "OrdersTabItems",
                newName: "OrdersItemsTab");

            migrationBuilder.RenameTable(
                name: "ItemOrdersTabItems",
                newName: "ItemOrderAdditional");

            migrationBuilder.RenameColumn(
                name: "OrderTabId",
                table: "OrdersItemsTab",
                newName: "TabId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrdersTabItems_ItemId",
                table: "ItemOrderAdditional",
                newName: "IX_ItemOrderAdditional_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrdersTabItems_AdditionalId",
                table: "ItemOrderAdditional",
                newName: "IX_ItemOrderAdditional_AdditionalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tab",
                table: "Tab",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersItemsTab",
                table: "OrdersItemsTab",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemOrderAdditional",
                table: "ItemOrderAdditional",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrderAdditional_Additionals_AdditionalId",
                table: "ItemOrderAdditional",
                column: "AdditionalId",
                principalTable: "Additionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrderAdditional_Items_ItemId",
                table: "ItemOrderAdditional",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Tab_TabModelId",
                table: "Payments",
                column: "TabModelId",
                principalTable: "Tab",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrderAdditional_Additionals_AdditionalId",
                table: "ItemOrderAdditional");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrderAdditional_Items_ItemId",
                table: "ItemOrderAdditional");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Tab_TabModelId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tab",
                table: "Tab");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersItemsTab",
                table: "OrdersItemsTab");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemOrderAdditional",
                table: "ItemOrderAdditional");

            migrationBuilder.RenameTable(
                name: "Tab",
                newName: "Tabs");

            migrationBuilder.RenameTable(
                name: "OrdersItemsTab",
                newName: "OrdersTabItems");

            migrationBuilder.RenameTable(
                name: "ItemOrderAdditional",
                newName: "ItemOrdersTabItems");

            migrationBuilder.RenameColumn(
                name: "TabId",
                table: "OrdersTabItems",
                newName: "OrderTabId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrderAdditional_ItemId",
                table: "ItemOrdersTabItems",
                newName: "IX_ItemOrdersTabItems_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrderAdditional_AdditionalId",
                table: "ItemOrdersTabItems",
                newName: "IX_ItemOrdersTabItems_AdditionalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tabs",
                table: "Tabs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersTabItems",
                table: "OrdersTabItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemOrdersTabItems",
                table: "ItemOrdersTabItems",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OrdersTab",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TabId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersTab", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdersTab_Tabs_TabId",
                        column: x => x.TabId,
                        principalTable: "Tabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdersTab_TabId",
                table: "OrdersTab",
                column: "TabId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrdersTabItems_Additionals_AdditionalId",
                table: "ItemOrdersTabItems",
                column: "AdditionalId",
                principalTable: "Additionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrdersTabItems_Items_ItemId",
                table: "ItemOrdersTabItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Tabs_TabModelId",
                table: "Payments",
                column: "TabModelId",
                principalTable: "Tabs",
                principalColumn: "Id");
        }
    }
}

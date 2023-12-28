using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_app_sr.Infra.Migrations
{
    /// <inheritdoc />
    public partial class SecondM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuickSales",
                columns: table => new
                {
                    QuickSaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuickSales", x => x.QuickSaleId);
                });

            migrationBuilder.CreateTable(
                name: "TabPayments",
                columns: table => new
                {
                    TabPaymentId = table.Column<Guid>(type: "uuid", nullable: false),
                    TabId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentType = table.Column<string>(type: "text", nullable: false),
                    IsChangeRequested = table.Column<bool>(type: "boolean", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Change = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabPayments", x => x.TabPaymentId);
                    table.ForeignKey(
                        name: "FK_TabPayments_Tabs_TabId",
                        column: x => x.TabId,
                        principalTable: "Tabs",
                        principalColumn: "TabId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuickSaleItems",
                columns: table => new
                {
                    QuickSaleItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuickSaleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuickSaleItems", x => x.QuickSaleItemId);
                    table.ForeignKey(
                        name: "FK_QuickSaleItems_QuickSales_QuickSaleId",
                        column: x => x.QuickSaleId,
                        principalTable: "QuickSales",
                        principalColumn: "QuickSaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_TabId",
                table: "Deliveries",
                column: "TabId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuickSaleItems_QuickSaleId",
                table: "QuickSaleItems",
                column: "QuickSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_TabPayments_TabId",
                table: "TabPayments",
                column: "TabId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Tabs_TabId",
                table: "Deliveries",
                column: "TabId",
                principalTable: "Tabs",
                principalColumn: "TabId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Tabs_TabId",
                table: "Deliveries");

            migrationBuilder.DropTable(
                name: "QuickSaleItems");

            migrationBuilder.DropTable(
                name: "TabPayments");

            migrationBuilder.DropTable(
                name: "QuickSales");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_TabId",
                table: "Deliveries");
        }
    }
}

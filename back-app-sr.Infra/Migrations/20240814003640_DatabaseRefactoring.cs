using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_app_sr.Infra.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseRefactoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "TabPayments");

            migrationBuilder.DropColumn(
                name: "TabType",
                table: "Tabs");

            migrationBuilder.RenameColumn(
                name: "TabId",
                table: "Tabs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Items",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AdditionalId",
                table: "Additionals",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Status_New",
                table: "Tabs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            // Copia os dados para a nova coluna (se possível)
            migrationBuilder.Sql(@"
            UPDATE ""Tabs""
            SET ""Status_New"" = CASE
                WHEN ""Status"" = 'Opened' THEN 1
                WHEN ""Status"" = 'Closed' THEN 2
                ELSE 0
            END");

            // Remove a coluna antiga
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tabs");

            // Renomeia a nova coluna para o nome original
            migrationBuilder.RenameColumn(
                name: "Status_New",
                table: "Tabs",
                newName: "Status");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Items",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Items",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Items",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Additionals",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Additionals",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "AllowedAdditionals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    AdditionalId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllowedAdditionals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllowedAdditionals_Additionals_AdditionalId",
                        column: x => x.AdditionalId,
                        principalTable: "Additionals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllowedAdditionals_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryRegisterModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    DeliveryTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryRegisterModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalOrderItens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DeliveryRegisterId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalOrderItens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemOrdersTabItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    AdditionalId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrdersTabItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemOrdersTabItems_Additionals_AdditionalId",
                        column: x => x.AdditionalId,
                        principalTable: "Additionals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemOrdersTabItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "OrdersTabItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderTabId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersTabItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RegisterId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentType = table.Column<string>(type: "text", nullable: false),
                    IsChangeRequested = table.Column<bool>(type: "boolean", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Changevalue = table.Column<decimal>(type: "numeric", nullable: false),
                    DeliveryRegisterModelId = table.Column<Guid>(type: "uuid", nullable: true),
                    TabModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_DeliveryRegisterModel_DeliveryRegisterModelId",
                        column: x => x.DeliveryRegisterModelId,
                        principalTable: "DeliveryRegisterModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_Tabs_TabModelId",
                        column: x => x.TabModelId,
                        principalTable: "Tabs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllowedAdditionals_AdditionalId",
                table: "AllowedAdditionals",
                column: "AdditionalId");

            migrationBuilder.CreateIndex(
                name: "IX_AllowedAdditionals_ItemId",
                table: "AllowedAdditionals",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrdersTabItems_AdditionalId",
                table: "ItemOrdersTabItems",
                column: "AdditionalId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrdersTabItems_ItemId",
                table: "ItemOrdersTabItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersTab_TabId",
                table: "OrdersTab",
                column: "TabId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_DeliveryRegisterModelId",
                table: "Payments",
                column: "DeliveryRegisterModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_TabModelId",
                table: "Payments",
                column: "TabModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllowedAdditionals");

            migrationBuilder.DropTable(
                name: "ExternalOrderItens");

            migrationBuilder.DropTable(
                name: "ItemOrdersTabItems");

            migrationBuilder.DropTable(
                name: "OrdersTab");

            migrationBuilder.DropTable(
                name: "OrdersTabItems");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "DeliveryRegisterModel");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tabs",
                newName: "TabId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Items",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Additionals",
                newName: "AdditionalId");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            // Restaura a coluna original, se necessário
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "TabModel",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            // Copia os dados de volta, se possível
            migrationBuilder.Sql(@"
            UPDATE ""Tabs""
            SET ""Status"" = CASE
                WHEN ""Status"" = 1 THEN 'Open'
                WHEN ""Status"" = 2 THEN 'Closed'
                WHEN ""Status"" = 3 THEN 'Pending'
                ELSE ''
            END");

            // Remove a coluna temporária
            migrationBuilder.DropColumn(
                name: "Status_New",
                table: "Tabs");

            migrationBuilder.AddColumn<string>(
                name: "TabType",
                table: "Tabs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Items",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Items",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Additionals",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Additionals",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    DeliveryId = table.Column<Guid>(type: "uuid", nullable: false),
                    TabId = table.Column<Guid>(type: "uuid", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Telephone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.DeliveryId);
                    table.ForeignKey(
                        name: "FK_Deliveries_Tabs_TabId",
                        column: x => x.TabId,
                        principalTable: "Tabs",
                        principalColumn: "TabId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    TabId = table.Column<Guid>(type: "uuid", nullable: false),
                    AdditionalId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    Observation = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Tabs_TabId",
                        column: x => x.TabId,
                        principalTable: "Tabs",
                        principalColumn: "TabId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TabPayments",
                columns: table => new
                {
                    TabPaymentId = table.Column<Guid>(type: "uuid", nullable: false),
                    TabId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Change = table.Column<decimal>(type: "numeric", nullable: false),
                    IsChangeRequested = table.Column<bool>(type: "boolean", nullable: false),
                    PaymentType = table.Column<string>(type: "text", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_TabId",
                table: "Deliveries",
                column: "TabId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TabId",
                table: "Orders",
                column: "TabId");

            migrationBuilder.CreateIndex(
                name: "IX_TabPayments_TabId",
                table: "TabPayments",
                column: "TabId");
        }
    }
}

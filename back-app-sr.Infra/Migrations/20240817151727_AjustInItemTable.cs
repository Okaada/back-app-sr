using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_app_sr.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AjustInItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_DeliveryRegisterModel_DeliveryRegisterModelId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_DeliveryRegisterModelId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryRegisterModel",
                table: "DeliveryRegisterModel");

            migrationBuilder.DropColumn(
                name: "DeliveryRegisterModelId",
                table: "Payments");

            migrationBuilder.RenameTable(
                name: "DeliveryRegisterModel",
                newName: "DeliveryRegister");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Items",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "DeliveryRegister",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryRegister",
                table: "DeliveryRegister",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_RegisterId",
                table: "Payments",
                column: "RegisterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_DeliveryRegister_RegisterId",
                table: "Payments",
                column: "RegisterId",
                principalTable: "DeliveryRegister",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_DeliveryRegister_RegisterId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_RegisterId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryRegister",
                table: "DeliveryRegister");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "DeliveryRegister",
                newName: "DeliveryRegisterModel");

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryRegisterModelId",
                table: "Payments",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "DeliveryRegisterModel",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryRegisterModel",
                table: "DeliveryRegisterModel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_DeliveryRegisterModelId",
                table: "Payments",
                column: "DeliveryRegisterModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_DeliveryRegisterModel_DeliveryRegisterModelId",
                table: "Payments",
                column: "DeliveryRegisterModelId",
                principalTable: "DeliveryRegisterModel",
                principalColumn: "Id");
        }
    }
}

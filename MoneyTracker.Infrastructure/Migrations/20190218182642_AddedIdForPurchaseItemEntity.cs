using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyTracker.Infrastructure.Migrations
{
    public partial class AddedIdForPurchaseItemEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseItems",
                table: "PurchaseItems");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "PurchaseItems",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<Guid>(
                name: "PurchaseItemId",
                table: "PurchaseItems",
                nullable: false,
                defaultValueSql: "newsequentialid()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseItems",
                table: "PurchaseItems",
                column: "PurchaseItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_PurchaseId",
                table: "PurchaseItems",
                column: "PurchaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseItems",
                table: "PurchaseItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseItems_PurchaseId",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "PurchaseItemId",
                table: "PurchaseItems");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "PurchaseItems",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseItems",
                table: "PurchaseItems",
                columns: new[] { "PurchaseId", "Title", "Amount" });
        }
    }
}
